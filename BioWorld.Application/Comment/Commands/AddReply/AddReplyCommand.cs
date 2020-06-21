using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Configuration;
using BioWorld.Application.Core;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Options;

namespace BioWorld.Application.Comment.Commands.AddReply
{
    public class AddReplyCommand : IRequest<CommentReplyDetailDto>
    {
        public AddReplyCmdDto AddReplyCmd { get; set; }
    }

    public class AddReplyCommandHandler : IRequestHandler<AddReplyCommand, CommentReplyDetailDto>
    {
        private readonly IApplicationDbContext _context;

        private readonly BlogConfigSetting _blogConfig;

        public AddReplyCommandHandler(IApplicationDbContext context,
            IOptions<BlogConfigSetting> settings = null)
        {
            if (null != settings) _blogConfig = settings.Value;
            _context = context;
        }

        public async Task<CommentReplyDetailDto> Handle(AddReplyCommand request, CancellationToken cancellationToken)
        {
            if (!_blogConfig.ContentSettings.EnableComments)
            {
                throw new BadRequestException(
                    $"{nameof(_blogConfig.ContentSettings.EnableComments)} can not be less than 1, current value: {_blogConfig.ContentSettings.EnableComments}.");
            }

            var cmt = await _context.Comment.FindAsync(request.AddReplyCmd.CommentId);

            if (null == cmt)
            {
                throw new NotFoundException(nameof(CommentEntity), request.AddReplyCmd.CommentId);
            }

            var id = Guid.NewGuid();
            var model = new CommentReplyEntity
            {
                Id = id,
                ReplyContent = request.AddReplyCmd.ReplyContent,
                IpAddress = request.AddReplyCmd.IpAddress,
                UserAgent = request.AddReplyCmd.UserAgent,
                ReplyTimeUtc = DateTime.UtcNow,
                CommentId = request.AddReplyCmd.CommentId
            };

            await _context.CommentReply.AddAsync(model, cancellationToken);

            var detail = new CommentReplyDetailDto()
            {
                CommentContent = cmt.CommentContent,
                CommentId = request.AddReplyCmd.CommentId,
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