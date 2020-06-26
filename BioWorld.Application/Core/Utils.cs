using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Markdig;

namespace BioWorld.Application.Core
{
    public static class Utils
    {
        public enum MarkdownConvertType
        {
            None = 0,
            Html = 1,
            Text = 2
        }

        public static string AppVersion =>
            (Assembly.GetEntryAssembly() ?? throw new InvalidOperationException())
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;

        public static IDictionary<string, string> GetThemes()
        {
            var dic = new Dictionary<string, string>
            {
                {"Word Blue", "word-blue.css"},
                {"Excel Green", "excel-green.css"},
                {"PowerPoint Orange", "powerpoint-orange.css"},
                {"OneNote Purple", "onenote-purple.css"},
                {"Outlook Blue", "outlook-blue.css"}
            };
            return dic;
        }

        public static string ConvertMarkdownContent(string markdown, MarkdownConvertType type, bool disableHtml = true)
        {
            var pipeline = GetMoongladeMarkdownPipelineBuilder();
        
            if (disableHtml)
            {
                pipeline.DisableHtml();
            }
        
            var result = type switch
            {
                MarkdownConvertType.None => markdown,
                MarkdownConvertType.Html => Markdown.ToHtml(markdown, pipeline.Build()),
                MarkdownConvertType.Text => Markdown.ToPlainText(markdown, pipeline.Build()),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        
            return result;
        }

        public static string NormalizeTagName(string orgTagName)
        {
            return ReplaceWithStringBuilder(orgTagName, TagNormalizeSourceTable).ToLower();
        }

        public static string GetPostAbstract(string rawContent, int wordCount, bool useMarkdown = false)
        {
            var plainText = useMarkdown ?
                ConvertMarkdownContent(rawContent, MarkdownConvertType.Text) :
                RemoveTags(rawContent);

            var result = plainText.Ellipsize(wordCount);
            return result;
        }

        public static bool ValidateTagName(string tagDisplayName)
        {
            if (string.IsNullOrWhiteSpace(tagDisplayName))
            {
                return false;
            }

            // Regex performance best practice
            // See https://docs.microsoft.com/en-us/dotnet/standard/base-types/best-practices

            const string pattern = @"^[a-zA-Z 0-9\.\-\+\#\s]*$";
            return Regex.IsMatch(tagDisplayName, pattern);
        }


        private static readonly Tuple<string, string>[] TagNormalizeSourceTable =
        {
            Tuple.Create(".", "dot"),
            Tuple.Create("#", "sharp"),
            Tuple.Create(" ", "-")
        };

        private static string ReplaceWithStringBuilder(string value, IEnumerable<Tuple<string, string>> toReplace)
        {
            var result = new StringBuilder(value);
            foreach (var (item1, item2) in toReplace)
            {
                result.Replace(item1, item2);
            }

            return result.ToString();
        }

        private static MarkdownPipelineBuilder GetMoongladeMarkdownPipelineBuilder()
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UsePipeTables()
                .UseBootstrap();

            return pipeline;
        }

        private static string RemoveTags(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                return string.Empty;
            }

            var result = new char[html.Length];

            var cursor = 0;
            var inside = false;
            foreach (var current in html)
            {
                switch (current)
                {
                    case '<':
                        inside = true;
                        continue;
                    case '>':
                        inside = false;
                        continue;
                }

                if (!inside)
                {
                    result[cursor++] = current;
                }
            }

            var stringResult = new string(result, 0, cursor);

            return stringResult.Replace("&nbsp;", " ");
        }

        private static bool IsLetter(this char c)
        {
            return 'A' <= c && c <= 'Z' || 'a' <= c && c <= 'z';
        }

        private static bool IsSpace(this char c)
        {
            return c == '\r' || c == '\n' || c == '\t' || c == '\f' || c == ' ';
        }

        private static string Ellipsize(this string text, int characterCount, string ellipsis, bool wordBoundary = false)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            if (characterCount < 0 || text.Length <= characterCount)
                return text;

            // search beginning of word
            var backup = characterCount;
            while (characterCount > 0 && text[characterCount - 1].IsLetter())
            {
                characterCount--;
            }

            // search previous word
            while (characterCount > 0 && text[characterCount - 1].IsSpace())
            {
                characterCount--;
            }

            // if it was the last word, recover it, unless boundary is requested
            if (characterCount == 0 && !wordBoundary)
            {
                characterCount = backup;
            }

            var trimmed = text.Substring(0, characterCount);
            return trimmed + ellipsis;
        }

        private static string Ellipsize(this string text, int characterCount)
        {
            return text.Ellipsize(characterCount, "\u00A0\u2026");
        }
    }
}