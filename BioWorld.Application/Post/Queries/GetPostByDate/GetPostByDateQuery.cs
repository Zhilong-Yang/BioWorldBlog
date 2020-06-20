using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Category;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Common.Models;
using BioWorld.Application.Tag.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetPostByDate
{
    public class GetPostByDateQuery : IRequest<PostSlugDto>
    {
        public QueryDateSlug queryDateSlug { get; set; }
    }

    public class GetPostByDateQueryHandler : IRequestHandler<GetPostByDateQuery, PostSlugDto>
    {
        private readonly IApplicationDbContext _context;

        public GetPostByDateQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostSlugDto> Handle(GetPostByDateQuery request,
            CancellationToken cancellationToken)
        {
            var date = new DateTime(request.queryDateSlug.Year, request.queryDateSlug.Month, request.queryDateSlug.Day);

            var pds = await _context.Post
                .Where(p => p.Slug == request.queryDateSlug.Slug &&
                            p.PostPublish.IsPublished &&
                            p.PostPublish.PubDateUtc.Value.Date == date &&
                            !p.PostPublish.IsDeleted)
                .Include(p => p.PostPublish)
                .Include(p => p.PostExtension)
                .Include(p => p.Comment)
                .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                .AsNoTracking()
                .Select(p => new PostSlugDto()
                {
                    Title = p.Title,
                    Abstract = p.ContentAbstract,
                    PubDateUtc = p.PostPublish.PubDateUtc.GetValueOrDefault(),
                    Content = p.PostContent,
                    Hits = p.PostExtension.Hits,
                    Likes = p.PostExtension.Likes,
                    PostId = p.Id,
                    CommentEnabled = p.CommentEnabled,
                    IsExposedToSiteMap = p.PostPublish.ExposedToSiteMap,
                    LastModifyOnUtc = p.PostPublish.LastModifiedUtc,

                    //CommentCount = p.Comment.Count(c => c.IsApproved == true),

                    Tags = p.PostTag.Select(pt => pt.Tag)
                        .Select(p => new TagDto()
                        {
                            NormalizedName = p.NormalizedName,
                            TagName = p.DisplayName
                        }).ToList(),

                    Categories = p.PostCategory.Select(pc => pc.Category)
                        .Select(p => new CategoryDto()
                        {
                            Id = p.Id,
                            DisplayName = p.DisplayName,
                            RouteName = p.RouteName
                        }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);


            return pds;
        }
    }
}