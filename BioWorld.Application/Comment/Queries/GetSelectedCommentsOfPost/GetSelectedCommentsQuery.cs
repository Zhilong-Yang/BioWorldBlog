using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Comment.Queries.GetPagedComment;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Comment.Queries.GetSelectedCommentsOfPost
{
    public class GetSelectedCommentsQuery : IRequest<PostCommentListItemJsonDto>
    {
        public Guid PostId { get; set; }
    }

    public class GetSelectedCommentsQueryHandler : IRequestHandler<GetSelectedCommentsQuery, PostCommentListItemJsonDto>
    {
        private readonly IApplicationDbContext _context;

        public GetSelectedCommentsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostCommentListItemJsonDto> Handle(GetSelectedCommentsQuery request, CancellationToken cancellationToken)
        {
            var pcl = await _context.Comment
                .Where(c => c.PostId == request.PostId && c.IsApproved)
                .Include(c => c.CommentReply)
                .Select(c => new PostCommentListItemDto()
                {
                    CommentContent = c.CommentContent,
                    CreateOnUtc = c.CreateOnUtc,
                    Username = c.Username,
                    Email = c.Email,
                    CommentReplies = c.CommentReply.Select(cr => new CommentReplyDigestDto
                    {
                        ReplyContent = cr.ReplyContent,
                        ReplyTimeUtc = cr.ReplyTimeUtc
                    }).ToList()
                })
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new PostCommentListItemJsonDto(pcl);
        }
    }
}