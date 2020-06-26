using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities.Cfg;
using MediatR;

namespace BioWorld.Application.Setting.Commands.UpdateFriendLinksSetting
{
    public class UpdateFriendLinksSettingCommand : IRequest
    {
        public Guid Id { get; set; }

        public bool ShowFriendLinksSection { get; set; }
    }

    public class UpdateFriendLinksSettingCommandHandler : IRequestHandler<UpdateFriendLinksSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        public UpdateFriendLinksSettingCommandHandler(IApplicationDbContext context, IBlogConfigService blogConfig)
        {
            _context = context;
            _blogConfig = blogConfig;
        }

        public async Task<Unit> Handle(UpdateFriendLinksSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FriendLinksSettings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FriendLinksSettingsEntity), request.Id);
            }

            var settings = _blogConfig.FriendLinksSettings;

            settings.ShowFriendLinksSection = request.ShowFriendLinksSection;
            entity.ShowFriendLinksSection = request.ShowFriendLinksSection;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}