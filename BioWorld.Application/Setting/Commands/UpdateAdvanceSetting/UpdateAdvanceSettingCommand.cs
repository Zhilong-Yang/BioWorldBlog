using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities.Cfg;
using MediatR;

namespace BioWorld.Application.Setting.Commands.UpdateAdvanceSetting
{
    public class UpdateAdvanceSettingCommand : IRequest
    {
        public Guid Id { get; set; }

        public string DnsPrefetchEndpoint { get; set; }

        public string RobotsTxtContent { get; set; }

        public bool EnablePingbackSend { get; set; }

        public bool EnablePingbackReceive { get; set; }
    }

    public class UpdateAdvanceSettingCommandHandler : IRequestHandler<UpdateAdvanceSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        public UpdateAdvanceSettingCommandHandler(IApplicationDbContext context, IBlogConfigService blogConfig)
        {
            _context = context;
            _blogConfig = blogConfig;
        }

        public async Task<Unit> Handle(UpdateAdvanceSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.AdvancedSettings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AdvancedSettingsEntity), request.Id);
            }

            var settings = _blogConfig.AdvancedSettings;
            settings.DNSPrefetchEndpoint = request.DnsPrefetchEndpoint;
            settings.RobotsTxtContent = request.RobotsTxtContent;
            settings.EnablePingBackSend = request.EnablePingbackSend;
            settings.EnablePingBackReceive = request.EnablePingbackReceive;

            entity.DNSPrefetchEndpoint = request.DnsPrefetchEndpoint;
            entity.RobotsTxtContent = request.RobotsTxtContent;
            entity.EnablePingBackSend = request.EnablePingbackSend;
            entity.EnablePingBackReceive = request.EnablePingbackReceive;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}