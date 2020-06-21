﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Category;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Tag.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetPostByDate
{
    public class GetPostByDateQuery : IRequest<PostSlugDto>
    {
        public DateSlugCmdDto DateSlugCmdDto { get; set; }
    }

    public class GetPostByDateQueryHandler : IRequestHandler<GetPostByDateQuery, PostSlugDto>
    {
        private readonly IApplicationDbContext _context;

        public GetPostByDateQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// zhilong TO DO fix this bug
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public async Task<PostSlugDto> Handle(GetPostByDateQuery request,
            CancellationToken cancellationToken)
        {
            var date = new DateTime(request.DateSlugCmdDto.Year, request.DateSlugCmdDto.Month, request.DateSlugCmdDto.Day);

            var pds = await _context.Post
                .Where(p => p.Slug == request.DateSlugCmdDto.Slug &&
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

                    CommentCount = p.Comment.Count(c => c.IsApproved),

                    Tags = p.PostTag.Select(pt => pt.Tag)
                        .Select(t => new TagDto()
                        {
                            NormalizedName = t.NormalizedName,
                            TagName = t.DisplayName
                        }).ToList(),

                    Categories = p.PostCategory.Select(pc => pc.Category)
                        .Select(c => new CategoryDto()
                        {
                            Id = c.Id,
                            DisplayName = c.DisplayName,
                            RouteName = c.RouteName
                        }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken);

            return pds;
        }
    }
}