using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities.Cfg;
using MediatR;

namespace BioWorld.Application.Setting.Commands.UpdateContentSetting
{
    public class UpdateContentSettingCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool EnableComments { get; set; }
        public bool RequireCommentReview { get; set; }
        public string DisharmonyWords { get; set; }
        public bool EnableWordFilter { get; set; }
        public bool UseFriendlyNotFoundImage { get; set; }
        public int PostListPageSize { get; set; }
        public int HotTagAmount { get; set; }
        public bool EnableGravatar { get; set; }
        public string CalloutSectionHtmlPitch { get; set; }
        public bool ShowCalloutSection { get; set; }
        public bool ShowPostFooter { get; set; }
        public string PostFooterHtmlPitch { get; set; }
    }

    public class UpdateContentSettingCommandHandler : IRequestHandler<UpdateContentSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        private readonly IBlogConfigService _blogConfig;

        public UpdateContentSettingCommandHandler(IApplicationDbContext context, IBlogConfigService blogConfig)
        {
            _context = context;
            _blogConfig = blogConfig;
        }

        public async Task<Unit> Handle(UpdateContentSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContentSettings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ContentSettingsEntity), request.Id);
            }

            var settings = _blogConfig.ContentSettings;

            settings.DisharmonyWords = request.DisharmonyWords;
            settings.EnableComments = request.EnableComments;
            settings.RequireCommentReview = request.RequireCommentReview;
            settings.EnableWordFilter = request.EnableWordFilter;
            settings.UseFriendlyNotFoundImage = request.UseFriendlyNotFoundImage;
            settings.PostListPageSize = request.PostListPageSize;
            settings.HotTagAmount = request.HotTagAmount;
            settings.EnableGravatar = request.EnableGravatar;
            settings.ShowCalloutSection = request.ShowCalloutSection;
            settings.CalloutSectionHtmlPitch = request.CalloutSectionHtmlPitch;
            settings.ShowPostFooter = request.ShowPostFooter;
            settings.PostFooterHtmlPitch = request.PostFooterHtmlPitch;

            entity.DisharmonyWords = request.DisharmonyWords;
            entity.EnableComments = request.EnableComments;
            entity.RequireCommentReview = request.RequireCommentReview;
            entity.EnableWordFilter = request.EnableWordFilter;
            entity.UseFriendlyNotFoundImage = request.UseFriendlyNotFoundImage;
            entity.PostListPageSize = request.PostListPageSize;
            entity.HotTagAmount = request.HotTagAmount;
            entity.EnableGravatar = request.EnableGravatar;
            entity.ShowCalloutSection = request.ShowCalloutSection;
            entity.CalloutSectionHtmlPitch = request.CalloutSectionHtmlPitch;
            entity.ShowPostFooter = request.ShowPostFooter;
            entity.PostFooterHtmlPitch = request.PostFooterHtmlPitch;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}