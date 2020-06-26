using FluentValidation;

namespace BioWorld.Application.Setting.Commands.UpdateFriendLinksSetting
{
    public class UpdateFriendLinksSettingCommandValidator : AbstractValidator<UpdateFriendLinksSettingCommand>
    {
        public UpdateFriendLinksSettingCommandValidator()
        {
            RuleFor(v => v.ShowFriendLinksSection)
                .NotNull().WithMessage("ShowFriendLinksSection is required.");
        }
    }
}