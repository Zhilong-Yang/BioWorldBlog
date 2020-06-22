using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Queries.GetRawContent
{
    public class GetRawContentQuery : IRequest<PostRawContentDto>
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Slug { get; set; }
    }

    public class GetPostByDateQueryHandler : IRequestHandler<GetRawContentQuery, PostRawContentDto>
    {
        private readonly IApplicationDbContext _context;

        public GetPostByDateQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostRawContentDto> Handle(GetRawContentQuery request, CancellationToken cancellationToken)
        {
            var date = new DateTime(request.Year, request.Month, request.Day);

            var content = await _context.Post
                .Where(p => p.Slug == request.Slug &&
                            p.PostPublish.IsPublished &&
                            p.PostPublish.PubDateUtc.Value.Date == date &&
                            !p.PostPublish.IsDeleted)
                .Include(p => p.PostPublish)
                .Include(p => p.PostExtension)
                .Include(p => p.Comment)
                .Include(p => p.PostTag).ThenInclude(pt => pt.Tag)
                .Include(p => p.PostCategory).ThenInclude(pc => pc.Category)
                .Select(post => post.PostContent)
                .FirstOrDefaultAsync(cancellationToken);

            return new PostRawContentDto(content);
        }
    }
}