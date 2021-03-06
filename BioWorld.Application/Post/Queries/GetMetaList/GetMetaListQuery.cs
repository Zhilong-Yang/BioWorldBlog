﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetMetaList
{
    public class GetMetaListQuery : IRequest<PostMetaDataJsonDto>
    {
        public PostPublishStatus PostPublishStatus { get; set; }
    }

    public class GetMetaListQueryHandler : IRequestHandler<GetMetaListQuery, PostMetaDataJsonDto>
    {
        private readonly IApplicationDbContext _context;

        public Expression<Func<PostEntity, bool>> Criteria { get; set; }

        public GetMetaListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostMetaDataJsonDto> Handle(GetMetaListQuery request,
            CancellationToken cancellationToken)
        {
            switch (request.PostPublishStatus)
            {
                case PostPublishStatus.Draft:
                    Criteria = (p => !p.PostPublish.IsPublished && !p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.Published:
                    Criteria = (p => p.PostPublish.IsPublished && !p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.Deleted:
                    Criteria = (p => p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.NotSet:
                    Criteria = (p => true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(PostPublishStatus), request.PostPublishStatus, null);
            }

            var post = await _context.Post
                .Include(p => p.PostPublish)
                .Where(Criteria)
                //.AsNoTracking()
                .Select(p => new PostMetaDataDto()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Slug = p.Slug,
                    PubDateUtc = p.PostPublish.PubDateUtc,
                    IsPublished = p.PostPublish.IsPublished,
                    IsDeleted = p.PostPublish.IsDeleted,
                    Revision = p.PostPublish.Revision,
                    CreateOnUtc = p.CreateOnUtc,
                    Hits = p.PostExtension.Hits
                })
                .ToListAsync(cancellationToken);

            return new PostMetaDataJsonDto(post);
        }
    }
}