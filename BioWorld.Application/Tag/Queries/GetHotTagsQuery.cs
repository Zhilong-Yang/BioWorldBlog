using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Queries
{
    public class GetHotTagsQuery : IRequest<List<TagCountInfo>>
    {
        public int Top { get; set; }
    }

    public class GetHotTagsQueryHandler : IRequestHandler<GetHotTagsQuery, List<TagCountInfo>>
    {
        private readonly IApplicationDbContext _context;

        public GetHotTagsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TagCountInfo>> Handle(GetHotTagsQuery request,
            CancellationToken cancellationToken)
        {
            if (_context.Tag.Any())
            {
                var hotTags = await _context.Tag
                    .AsNoTracking()
                    .OrderByDescending(p => p.PostTag.Count)
                    .Skip(0)
                    .Take(request.Top)
                    .Select(t => new TagCountInfo
                    {
                        Id = t.Id,
                        TagCount = t.PostTag.Count,
                        TagName = t.DisplayName,
                        NormalizedName = t.NormalizedName
                    })
                    .ToListAsync(cancellationToken);

                return hotTags;
            }

            return new List<TagCountInfo>();
        }
    }
}