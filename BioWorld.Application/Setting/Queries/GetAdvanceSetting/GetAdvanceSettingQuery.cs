using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Setting.Queries.GetAdvanceSetting
{
    public class GetAdvanceSettingQuery : IRequest<AdvanceSettingDto>
    {
        public class GetAdvanceSettingQueryHandler : IRequestHandler<GetAdvanceSettingQuery, AdvanceSettingDto>
        {
            private readonly IApplicationDbContext _context;

            public GetAdvanceSettingQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<AdvanceSettingDto> Handle(GetAdvanceSettingQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.AdvancedSettings.Select(c => new AdvanceSettingDto
                    {
                        DNSPrefetchEndpoint = c.DNSPrefetchEndpoint,
                        RobotsTxtContent = c.RobotsTxtContent,
                        EnablePingbackSend = c.EnablePingBackSend,
                        EnablePingbackReceive = c.EnablePingBackReceive
                    })
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return entity;
            }
        }
    }
}