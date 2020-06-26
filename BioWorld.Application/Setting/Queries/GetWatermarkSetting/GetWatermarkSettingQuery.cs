using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Setting.Queries.GetWatermarkSetting
{
    public class GetWatermarkSettingQuery : IRequest<WatermarkSettingsDto>
    {
        public class GetWatermarkSettingQueryHandler : IRequestHandler<GetWatermarkSettingQuery, WatermarkSettingsDto>
        {
            private readonly IApplicationDbContext _context;

            public GetWatermarkSettingQueryHandler(IApplicationDbContext context)
            {
                if (null != context) _context = context;
            }

            public async Task<WatermarkSettingsDto> Handle(GetWatermarkSettingQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.WatermarkSettings
                    .Select(c => new WatermarkSettingsDto
                    {
                        Id = c.Id,
                        IsEnabled = c.IsEnabled,
                        KeepOriginImage = c.KeepOriginImage,
                        FontSize = c.FontSize,
                        WatermarkText = c.WatermarkText
                    })
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return entity;
            }
        }
    }
}