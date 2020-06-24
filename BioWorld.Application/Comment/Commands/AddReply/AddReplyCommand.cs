using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Core;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BioWorld.Application.Comment.Commands.AddReply
{
    public class AddReplyCommand : IRequest<CommentReplyDetailDto>
    {
        public Guid CommentId { get; set; }
        public string ReplyContent { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
    }

    public class AddReplyCommandHandler : IRequestHandler<AddReplyCommand, CommentReplyDetailDto>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        public AddReplyCommandHandler(IApplicationDbContext context,
            IBlogConfigService settings)
        {
            if (null != settings) _blogConfig = settings;
            _context = context;
        }

        public async Task<CommentReplyDetailDto> Handle(AddReplyCommand request, CancellationToken cancellationToken)
        {
            if (!_blogConfig.ContentSettings.EnableComments)
            {
                throw new BadRequestException(
                    $"{nameof(_blogConfig.ContentSettings.EnableComments)} can not be less than 1, current value: {_blogConfig.ContentSettings.EnableComments}.");
            }

            var cmt = await _context.Comment
                .Where(c =>c.Id ==request.CommentId)
                .Include(c =>c.Post)
                .ThenInclude(d=>d.PostPublish)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (null == cmt)
            {
                throw new NotFoundException(nameof(CommentEntity), request.CommentId);
            }

            var id = Guid.NewGuid();
            var model = new CommentReplyEntity
            {
                Id = id,
                ReplyContent = request.ReplyContent,
                IpAddress = request.IpAddress,
                UserAgent = request.UserAgent,
                ReplyTimeUtc = DateTime.UtcNow,
                CommentId = request.CommentId
            };

            await _context.CommentReply.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var detail = new CommentReplyDetailDto()
            {
                CommentContent = cmt.CommentContent,
                CommentId = request.CommentId,
                Email = cmt.Email,
                Id = model.Id,
                IpAddress = model.IpAddress,
                PostId = cmt.PostId,
                PubDateUtc = cmt.Post.PostPublish.PubDateUtc.GetValueOrDefault(),
                ReplyContent = model.ReplyContent,
                ReplyContentHtml = Utils.ConvertMarkdownContent(model.ReplyContent, Utils.MarkdownConvertType.Html),
                ReplyTimeUtc = model.ReplyTimeUtc,
                Slug = cmt.Post.Slug,
                Title = cmt.Post.Title,
                UserAgent = model.UserAgent
            };

            return detail;
        }
    }
}