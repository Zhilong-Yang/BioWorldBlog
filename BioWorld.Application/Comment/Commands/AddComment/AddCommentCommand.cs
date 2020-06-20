using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Post.Commands.CreatePost;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Comment.Commands.AddComment
{
    public class AddCommentCommand : IRequest
    {
        public Guid PostId { get; }

        public string Username { get; set; }

        public string Content { get; set; }

        public string Email { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }
    }

    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddCommentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            // 1. Check comment enabled or not

            // 2. Harmonize banned keywords

            var model = new CommentEntity
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                CommentContent = request.Content,
                PostId = request.PostId,
                CreateOnUtc = DateTime.UtcNow,
                Email = request.Email,
                IPAddress = request.IpAddress,
                //IsApproved = !_blogConfig.ContentSettings.RequireCommentReview,
                UserAgent = request.UserAgent
            };

            return Unit.Value;
        }
    }
}
