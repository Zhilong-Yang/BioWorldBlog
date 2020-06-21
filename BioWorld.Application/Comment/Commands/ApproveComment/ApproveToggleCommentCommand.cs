using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Comment.Commands.ApproveComment
{
    public class ApproveToggleCommentCommand : IRequest
    {
        public Guid[] CommentIds { get; set; }
    }

    public class AddReplyCommandHandler : IRequestHandler<ApproveToggleCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddReplyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ApproveToggleCommentCommand request, CancellationToken cancellationToken)
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
                cmt.IsApproved = !cmt.IsApproved;
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}