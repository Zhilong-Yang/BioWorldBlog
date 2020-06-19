using System;
using System.Collections.Generic;
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
    public class GetMetaListQuery : IRequest<IReadOnlyList<PostMetaDataDto>>
    {
        public PostPublishStatus PostPublishStatus { get; set; }
    }

    public class GetMetaListQueryHandler : IRequestHandler<GetMetaListQuery, IReadOnlyList<PostMetaDataDto>>
    {
        private readonly IApplicationDbContext _context;

        public Expression<Func<PostEntity, bool>> _criteria { get; set; }

        public GetMetaListQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<PostMetaDataDto>> Handle(GetMetaListQuery request,
            CancellationToken cancellationToken)
        {
            switch (request.PostPublishStatus)
            {
                case PostPublishStatus.Draft:
                    _criteria = (p => !p.PostPublish.IsPublished && !p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.Published:
                    _criteria = (p => p.PostPublish.IsPublished && !p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.Deleted:
                    _criteria = (p => p.PostPublish.IsDeleted);
                    break;
                case PostPublishStatus.NotSet:
                    _criteria = (p => true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(PostPublishStatus), request.PostPublishStatus, null);
            }

            var post = await _context.Post
                .Include(p => p.PostPublish)
                .Where(_criteria)
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

            return post;
        }
    }
}