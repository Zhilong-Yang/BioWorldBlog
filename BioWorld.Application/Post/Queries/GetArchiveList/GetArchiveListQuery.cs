using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BioWorld.Application.Post.Queries.GetArchiveList
{
    public class GetArchiveListQuery : IRequest<ArchiveJsonDto>
    {
        public class GetArchiveListQueryHandler : IRequestHandler<GetArchiveListQuery, ArchiveJsonDto>
        {
            private readonly IApplicationDbContext _context;

            public GetArchiveListQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ArchiveJsonDto> Handle(GetArchiveListQuery request,
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
                return new ArchiveJsonDto(list);
            }
        }
    }
}