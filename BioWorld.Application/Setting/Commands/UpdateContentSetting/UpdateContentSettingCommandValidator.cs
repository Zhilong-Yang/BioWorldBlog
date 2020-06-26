using FluentValidation;

namespace BioWorld.Application.Setting.Commands.UpdateContentSetting
{
    public class UpdateContentSettingCommandValidator: AbstractValidator<UpdateContentSettingCommand>
    {
        public UpdateContentSettingCommandValidator()
        {
            RuleFor(v => v.EnableComments)
                .NotNull().WithMessage("EnableComments is required.");
            RuleFor(v => v.RequireCommentReview)
                .NotNull().WithMessage("RequireCommentReview is required.");
            RuleFor(v => v.DisharmonyWords)
                .NotEmpty().WithMessage("DisharmonyWords is required.")
                .MaximumLength(2048).WithMessage("DisharmonyWords must not exceed 2048 characters.");
            RuleFor(v => v.EnableWordFilter)
                .NotNull().WithMessage("EnableWordFilter is required.");
            RuleFor(v => v.UseFriendlyNotFoundImage)
                .NotNull().WithMessage("UseFriendlyNotFoundImage is required.");
            RuleFor(v => v.PostListPageSize)
                .NotEmpty().WithMessage("PostListPageSize is required.")
                .InclusiveBetween(1,100);
            RuleFor(v => v.EnableComments)
                .NotNull().WithMessage("EnableComments is required.");
            RuleFor(v => v.HotTagAmount)
                .NotEmpty().WithMessage("HotTagAmount is required.")
                .InclusiveBetween(1,50);
            RuleFor(v => v.EnableGravatar)
                .NotNull().WithMessage("EnableGravatar is required.");
            RuleFor(v => v.CalloutSectionHtmlPitch)
                .MaximumLength(2048).WithMessage("CalloutSectionHtmlPitch must not exceed 2048 characters.");
        }
    }
}
