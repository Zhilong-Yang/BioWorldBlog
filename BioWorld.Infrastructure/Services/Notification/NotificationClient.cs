using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BioWorld.Application;
using BioWorld.Application.Comment.Commands.AddReply;
using BioWorld.Application.Comment.Queries.GetPagedComment;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace BioWorld.Infrastructure.Services.Notification
{
    public class NotificationClient : INotificationClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<NotificationClient> _logger;
        private readonly IBlogConfigService _blogConfigService;

        public bool IsEnabled { get; set; }

        public NotificationClient(HttpClient httpClient,
            IOptions<AppSettings> settings,
            ILogger<NotificationClient> logger,
            IBlogConfigService blogConfigS)
        {
            _httpClient = httpClient;
            _logger = logger;
            _blogConfigService = blogConfigS;

            if (settings.Value.Notification.Enabled)
            {
                if (Uri.IsWellFormedUriString(settings.Value.Notification.AzureFunctionEndpoint,
                    UriKind.Absolute))
                {
                    httpClient.BaseAddress = new Uri(settings.Value.Notification.AzureFunctionEndpoint);
                }

                httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, $"BioWorld/{Utils.AppVersion}");
                _httpClient = httpClient;

                if (_blogConfigService.NotificationSettings.EnableEmailSending)
                {
                    IsEnabled = true;
                }
            }
        }

        public async Task SendNewCommentNotificationAsync(CommentListItemWithReplyDto model,
            Func<string, string> funcCommentContentFormat)
        {
            if (!IsEnabled)
            {
                _logger.LogWarning(
                    $"Skipped {nameof(SendNewCommentNotificationAsync)} because Email sending is disabled.");
                await Task.CompletedTask;
                return;
            }

            try
            {
                var payload = new NewCommentNotificationPayload(
                    model.Username,
                    model.Email,
                    model.IpAddress,
                    model.PostTitle,
                    funcCommentContentFormat(model.CommentContent),
                    model.CreateOnUtc
                );

                await SendNotificationRequest(
                    new NotificationRequest<NewCommentNotificationPayload>(MailMessageTypes.NewCommentNotification,
                        payload));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

        public async Task SendCommentReplyNotificationAsync(CommentReplyDetailDto model, string postLink)
        {
            if (!IsEnabled)
            {
                _logger.LogWarning(
                    $"Skipped {nameof(SendCommentReplyNotificationAsync)} because Email sending is disabled.");
                await Task.CompletedTask;
                return;
            }

            try
            {
                var payload = new CommentReplyNotificationPayload(
                    model.Email,
                    model.CommentContent,
                    model.Title,
                    model.ReplyContentHtml,
                    postLink);

                await SendNotificationRequest(
                    new NotificationRequest<CommentReplyNotificationPayload>(MailMessageTypes.AdminReplyNotification,
                        payload));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

        private async Task SendNotificationRequest<T>(NotificationRequest<T> request,
            [CallerMemberName] string callerMemberName = "") where T : class
        {
            var req = BuildNotificationRequest(() => request);
            var response = await _httpClient.SendAsync(req);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error executing request '{callerMemberName}', response: {response.StatusCode}");
            }
        }

        private HttpRequestMessage BuildNotificationRequest<T>(Func<NotificationRequest<T>> request) where T : class
        {
            var nf = request();
            nf.EmailDisplayName = _blogConfigService.NotificationSettings.EmailDisplayName;
            nf.AdminEmail = _blogConfigService.NotificationSettings.AdminEmail;

            var req = new HttpRequestMessage(HttpMethod.Post, string.Empty)
            {
                Content = new NotificationContent<T>(nf)
            };
            return req;
        }
    }
}