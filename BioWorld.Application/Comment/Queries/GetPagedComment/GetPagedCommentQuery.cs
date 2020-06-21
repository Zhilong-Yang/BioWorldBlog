using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Comment.Queries.GetPagedComment
{
    public class GetPagedCommentQuery : IRequest<IReadOnlyList<CommentListItemWithReplyDto>>
    {
        public Paging Param { get; set; }
    }

    public class GetPagedCommentQueryHandler : IRequestHandler<GetPagedCommentQuery, IReadOnlyList<CommentListItemWithReplyDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPagedCommentQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<CommentListItemWithReplyDto>> Handle(GetPagedCommentQuery request,
            CancellationToken cancellationToken)
        {
            var pageSize = request.Param.PageSize;
            var pageIndex = request.Param.PageNumber;

            if (pageSize < 1)
            {
                throw new BadRequestException(
                    $"{nameof(pageSize)} can not be less than 1, current value: {pageSize}.");
            }

            if (pageIndex < 1)
            {
                throw new BadRequestException(
                    $"{nameof(pageIndex)} can not be less than 1, current value: {pageIndex}.");
            }

            var comments = await _context.Comment
                .Include(c => c.Post)
                .Include(c => c.CommentReply)
                .OrderByDescending(p => p.CreateOnUtc)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)

                .Select(p => new CommentListItemWithReplyDto()
                {
                    Id = p.Id,
                    CommentContent = p.CommentContent,
                    CreateOnUtc = p.CreateOnUtc,
                    Email = p.Email,
                    IpAddress = p.IPAddress,
                    Username = p.Username,
                    IsApproved = p.IsApproved,
                    PostTitle = p.Post.Title,

                    CommentRepliesDto = p.CommentReply.Select(cr => new CommentReplyDigestDto
                    {
                        ReplyContent = cr.ReplyContent,
                        ReplyTimeUtc = cr.ReplyTimeUtc
                    }).ToList()

                })

                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            return comments;
        }
    }
}