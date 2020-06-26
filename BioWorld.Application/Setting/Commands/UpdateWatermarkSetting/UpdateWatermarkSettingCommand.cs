using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities.Cfg;
using MediatR;

namespace BioWorld.Application.Setting.Commands.UpdateWatermarkSetting
{
    public class UpdateWatermarkSettingCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool IsEnabled { get; set; }
        public bool KeepOriginImage { get; set; }
        public int FontSize { get; set; }
        public string WatermarkText { get; set; }
    }

    public class UpdateWatermarkSettingCommandHandler : IRequestHandler<UpdateWatermarkSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        public UpdateWatermarkSettingCommandHandler(IApplicationDbContext context, IBlogConfigService blogConfig)
        {
            _context = context;
            _blogConfig = blogConfig;
        }

        public async Task<Unit> Handle(UpdateWatermarkSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.WatermarkSettings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(WatermarkSettingsEntity), request.Id);
            }

            var settings = _blogConfig.WatermarkSettings;

            settings.IsEnabled = request.IsEnabled;
            settings.KeepOriginImage = request.KeepOriginImage;
            settings.FontSize = request.FontSize;
            settings.WatermarkText = request.WatermarkText;

            entity.IsEnabled = request.IsEnabled;
            entity.KeepOriginImage = request.KeepOriginImage;
            entity.FontSize = request.FontSize;
            entity.WatermarkText = request.WatermarkText;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}