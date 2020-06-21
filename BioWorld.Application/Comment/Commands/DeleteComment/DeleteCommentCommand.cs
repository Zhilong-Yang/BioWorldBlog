using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Comment.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public Guid[] CommentIds { get; set; }
    }

    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCommentHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            if (null == request.CommentIds || !request.CommentIds.Any())
            {
                throw new BadRequestException(
                    $"{nameof(request.CommentIds)} can not be less than 1, current value: {request.CommentIds}.");
            }

            var comments = await _context.Comment
                .Where(c => request.CommentIds.Contains(c.Id))
                .ToListAsync(cancellationToken: cancellationToken);

            foreach (var cmt in comments)
            {
                // 1. Delete all replies
                var cReplies = await _context.CommentReply
                    .Where(cr => cr.CommentId == cmt.Id)
                    .ToListAsync(cancellationToken);

                if (cReplies.Any())
                {
                    _context.CommentReply.RemoveRange(cReplies);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                // 2. Delete comment itself
                _context.Comment.Remove(cmt);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}