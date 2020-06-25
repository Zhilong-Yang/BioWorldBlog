using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Comment.Commands.AddComment
{
    public class AddCommentCommand : IRequest<CommentListItemDto>
    {
        public Guid PostId { get; set; }

        public string Username { get; set; }

        public string Content { get; set; }

        public string Email { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }
    }

    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, CommentListItemDto>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        private readonly IMaskWordFilter _wordFilter;

        public AddCommentCommandHandler(IApplicationDbContext context,
            IBlogConfigService settings,
            IMaskWordFilter wordFilter)
        {
            if (null != settings) _blogConfig = settings;
            _context = context;
            _wordFilter = wordFilter;
        }

        public async Task<CommentListItemDto> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            // 1. Check comment enabled or not
            if (!_blogConfig.ContentSettings.EnableComments)
            {
                throw new BadRequestException(
                    $"{nameof(_blogConfig.ContentSettings.EnableComments)} can not be less than 1, current value: {_blogConfig.ContentSettings.EnableComments}.");
            }

            // 2. Harmonize banned keywords
            if (_blogConfig.ContentSettings.EnableWordFilter)
            {
                request.Username = _wordFilter.FilterContent(request.Username);
                request.Content = _wordFilter.FilterContent(request.Content);
            }

            var model = new CommentEntity
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                CommentContent = request.Content,
                PostId = request.PostId,
                CreateOnUtc = DateTime.UtcNow,
                Email = request.Email,
                IPAddress = request.IpAddress,
                IsApproved = !_blogConfig.ContentSettings.RequireCommentReview,
                UserAgent = request.UserAgent
            };

            await _context.Comment.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var postTitle = await _context.Post.Select(p => p.Title).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var item = new CommentListItemDto()
            {
                Id = model.Id,
                CommentContent = model.CommentContent,
                CreateOnUtc = model.CreateOnUtc,
                Email = model.Email,
                IpAddress = model.IPAddress,
                IsApproved = model.IsApproved,
                PostTitle = postTitle,
                Username = model.Username
            };
            return item;
        }
    }
}
