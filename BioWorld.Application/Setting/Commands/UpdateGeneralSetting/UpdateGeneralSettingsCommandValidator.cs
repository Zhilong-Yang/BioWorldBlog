using FluentValidation;

namespace BioWorld.Application.Setting.Commands.UpdateGeneralSetting
{
    public class UpdateGeneralSettingsCommandValidator : AbstractValidator<UpdateGeneralSettingsCommand>
    {
        public UpdateGeneralSettingsCommandValidator()
        {
            RuleFor(v => v.MetaKeyword)
                .NotEmpty().WithMessage("MetaKeyword is required.")
                .MaximumLength(1024).WithMessage("MetaKeyword must not exceed 1024 characters.");
            RuleFor(v => v.MetaDescription)
                .NotEmpty().WithMessage("MetaDescription is required.")
                .MaximumLength(1024).WithMessage("MetaDescription must not exceed 1024 characters.");
            RuleFor(v => v.CanonicalPrefix)
                .Matches(@"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?")
                .WithMessage("URL with http// or https://.")
                .MaximumLength(64).WithMessage("CanonicalPrefix must not exceed 64 characters.");
            RuleFor(v => v.LogoText)
                .NotEmpty().WithMessage("LogoText is required.")
                .MaximumLength(16).WithMessage("LogoText must not exceed 16 characters.");
            RuleFor(v => v.Copyright)
                .NotEmpty().WithMessage("Copyright is required.")
                .Matches(@"^[a-zA-Z0-9\s.\-\[\]]+$").WithMessage("Only letters, numbers, - and [] are allowed.")
                .MaximumLength(64).WithMessage("Copyright must not exceed 64 characters.");
            RuleFor(v => v.SiteTitle)
                .NotEmpty().WithMessage("SiteTitle is required.")
                .MaximumLength(16).WithMessage("SiteTitle must not exceed 16 characters.");
            RuleFor(v => v.OwnerName)
                .NotEmpty().WithMessage("OwnerName is required.")
                .MaximumLength(32).WithMessage("OwnerName must not exceed 32 characters.");
            RuleFor(v => v.OwnerDescription)
                .NotEmpty().WithMessage("OwnerDescription is required.")
                .MaximumLength(256).WithMessage("OwnerDescription must not exceed 256 characters.");
            RuleFor(v => v.OwnerShortDescription)
                .NotEmpty().WithMessage("OwnerShortDescription is required.")
                .MaximumLength(32).WithMessage("OwnerShortDescription must not exceed 32 characters.");
            RuleFor(v => v.SideBarCustomizedHtmlPitch)
                .MaximumLength(2048).WithMessage("SideBarCustomizedHtmlPitch must not exceed 2048 characters.");
            RuleFor(v => v.FooterCustomizedHtmlPitch)
                .MaximumLength(4096).WithMessage("FooterCustomizedHtmlPitch must not exceed 4096 characters.");
            RuleFor(v => v.SelectedTimeZoneId)
                .MaximumLength(64).WithMessage("SelectedTimeZoneId must not exceed 64 characters.");
            RuleFor(v => v.SelectedThemeFileName)
                .MaximumLength(32).WithMessage("SelectedThemeFileName must not exceed 32 characters.");
        }
    }
}