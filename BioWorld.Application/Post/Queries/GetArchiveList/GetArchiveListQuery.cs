using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BioWorld.Application.Post.Queries.GetArchiveList
{
    public class GetArchiveListQuery : IRequest<IReadOnlyList<ArchiveDto>>
    {
        public class GetArchiveListQueryHandler : IRequestHandler<GetArchiveListQuery, IReadOnlyList<ArchiveDto>>
        {
            private readonly IApplicationDbContext _context;

            public GetArchiveListQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IReadOnlyList<ArchiveDto>> Handle(GetArchiveListQuery request,
                CancellationToken cancellationToken)
            {
                if (!_context.Post.Any(p => p.PostPublish.IsPublished && !p.PostPublish.IsDeleted))
                {
                    return null;
                }

                var list = await _context.Post
                    .Where(p => p.PostPublish.IsPublished && !p.PostPublish.IsDeleted)
                    .Select(
                        pt => new ArchiveDto(
                            pt.PostPublish.PubDateUtc.Value.Year,
                            pt.PostPublish.PubDateUtc.Value.Month,
                            pt.Id,
                            1)
                    )
                    .ToListAsync(cancellationToken);

                int i = 0;
                foreach (var p in list)
                {
                    p.Count = i++;
                }
                return list;
            }
        }
    }
}