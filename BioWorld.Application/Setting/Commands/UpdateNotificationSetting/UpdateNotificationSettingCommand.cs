using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities.Cfg;
using MediatR;

namespace BioWorld.Application.Setting.Commands.UpdateNotificationSetting
{
    public class UpdateNotificationSettingCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool EnableEmailSending { get; set; }
        public bool SendEmailOnCommentReply { get; set; }
        public bool SendEmailOnNewComment { get; set; }
        public string AdminEmail { get; set; }
        public string EmailDisplayName { get; set; }
    }

    public class UpdateNotificationSettingCommandHandler : IRequestHandler<UpdateNotificationSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        public UpdateNotificationSettingCommandHandler(IApplicationDbContext context, IBlogConfigService blogConfig)
        {
            _context = context;
            _blogConfig = blogConfig;
        }

        public async Task<Unit> Handle(UpdateNotificationSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.NotificationSettings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NotificationSettingsEntity), request.Id);
            }

            var settings = _blogConfig.NotificationSettings;

            settings.AdminEmail = request.AdminEmail;
            settings.EmailDisplayName = request.EmailDisplayName;
            settings.EnableEmailSending = request.EnableEmailSending;
            settings.SendEmailOnCommentReply = request.SendEmailOnCommentReply;
            settings.SendEmailOnNewComment = request.SendEmailOnNewComment;

            entity.AdminEmail = request.AdminEmail;
            entity.EmailDisplayName = request.EmailDisplayName;
            entity.EnableEmailSending = request.EnableEmailSending;
            entity.SendEmailOnCommentReply = request.SendEmailOnCommentReply;
            entity.SendEmailOnNewComment = request.SendEmailOnNewComment;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}