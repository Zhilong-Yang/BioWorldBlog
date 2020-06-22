using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Post.Queries.GetAllPostListItem;
using BioWorld.Application.Tag.Queries;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.SearchPost
{
    public class SearchPostQuery : IRequest<PostListItemJsonDto>
    {
        public string Keyword { get; set; }
    }

    public class SearchPostQueryHandler : IRequestHandler<SearchPostQuery, PostListItemJsonDto>
    {
        private readonly IApplicationDbContext _context;

        public SearchPostQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostListItemJsonDto> Handle(SearchPostQuery request,
            CancellationToken cancellationToken)
        {
            var postList = SearchByKeyword(request.Keyword);

            var resultList = await postList
                .Select(p => new PostListItemDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Slug = p.Slug,
                    ContentAbstract = p.ContentAbstract,
                    PubDateUtc = p.PostPublish.PubDateUtc.GetValueOrDefault(),
                    Tags = p.PostTag.Select(pt => new TagDto()
                    {
                        Id = pt.TagId,
                        NormalizedName = pt.Tag.NormalizedName,
                        TagName = pt.Tag.DisplayName
                    }).ToList()
                })
                .ToListAsync(cancellationToken: cancellationToken);
            return new PostListItemJsonDto(resultList);
        }

        private IQueryable<PostEntity> SearchByKeyword(string keyword)
        {
            var query = _context.Post
                .Where(p => !p.PostPublish.IsDeleted && p.PostPublish.IsPublished).AsNoTracking();

            var str = Regex.Replace(keyword, @"\s+", " ");
            var rst = str.Split(' ');
            if (rst.Length > 1)
            {
                // keyword: "dot  net rocks"
                // search for post where Title containing "dot && net && rocks"
                var result = rst.Aggregate(query, (current, s) => current.Where(p => p.Title.Contains(s)));
                return result;
            }
            else
            {
                // keyword: "dotnetrocks"
                var k = rst.First();
                var result = query.Where(p => p.Title.Contains(k) ||
                                              p.PostTag.Select(pt => pt.Tag).Select(t => t.DisplayName).Contains(k));
                return result;
            }
        }
    }
}