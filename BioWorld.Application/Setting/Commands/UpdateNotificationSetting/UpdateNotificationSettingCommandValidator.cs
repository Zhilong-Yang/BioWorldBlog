using FluentValidation;

namespace BioWorld.Application.Setting.Commands.UpdateNotificationSetting
{
    public class UpdateNotificationSettingCommandValidator : AbstractValidator<UpdateNotificationSettingCommand>
    {
        public UpdateNotificationSettingCommandValidator()
        {
            RuleFor(v => v.AdminEmail)
                .NotEmpty().WithMessage("AdminEmail is required.")
                .EmailAddress().WithMessage("Invalid Email.")
                .MaximumLength(64).WithMessage("AdminEmail must not exceed 64 characters.");
            RuleFor(v => v.EmailDisplayName)
                .NotEmpty().WithMessage("EmailDisplayName is required.")
                .MaximumLength(64).WithMessage("EmailDisplayName must not exceed 64 characters.");
        }
    }
}
