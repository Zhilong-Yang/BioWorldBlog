using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities.Cfg;
using MediatR;

namespace BioWorld.Application.Setting.Commands.UpdateFeedSetting
{
    public class UpdateFeedSettingCommand : IRequest
    {
        public Guid Id { get; set; }
        public int RssItemCount { get; set; }
        public string RssCopyright { get; set; }
        public string RssDescription { get; set; }
        public string RssTitle { get; set; }
        public string AuthorName { get; set; }
        public bool UseFullContent { get; set; }
    }

    public class UpdateFeedSettingCommandHandler : IRequestHandler<UpdateFeedSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        public UpdateFeedSettingCommandHandler(IApplicationDbContext context, IBlogConfigService blogConfig)
        {
            _context = context;
            _blogConfig = blogConfig;
        }

        public async Task<Unit> Handle(UpdateFeedSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FeedSettings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FeedSettingsEntity), request.Id);
            }

            var settings = _blogConfig.FeedSettings;

            settings.AuthorName = request.AuthorName;
            settings.RssCopyright = request.RssCopyright;
            settings.RssDescription = request.RssDescription;
            settings.RssItemCount = request.RssItemCount;
            settings.RssTitle = request.RssTitle;
            settings.UseFullContent = request.UseFullContent;

            entity.AuthorName = request.AuthorName;
            entity.RssCopyright = request.RssCopyright;
            entity.RssDescription = request.RssDescription;
            entity.RssItemCount = request.RssItemCount;
            entity.RssTitle = request.RssTitle;
            entity.UseFullContent = request.UseFullContent;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}