using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Comment.Queries.GetCountComments
{
    public class GetCountCommentsQuery : IRequest<CommentCountDto>
    {
        public class GetCountCommentsQueryHandler : IRequestHandler<GetCountCommentsQuery, CommentCountDto>
        {
            private readonly IApplicationDbContext _context;

            public GetCountCommentsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<CommentCountDto> Handle(GetCountCommentsQuery request, CancellationToken cancellationToken)
            {
                var count = await _context.Comment.CountAsync(cancellationToken);

                return new CommentCountDto(count);
            }
        }
    }
}
