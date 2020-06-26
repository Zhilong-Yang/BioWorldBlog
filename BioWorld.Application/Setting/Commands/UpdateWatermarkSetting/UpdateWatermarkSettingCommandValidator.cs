using FluentValidation;

namespace BioWorld.Application.Setting.Commands.UpdateWatermarkSetting
{
    public class UpdateWatermarkSettingCommandValidator : AbstractValidator<UpdateWatermarkSettingCommand>
    {
        public UpdateWatermarkSettingCommandValidator()
        {
            RuleFor(v => v.IsEnabled)
                .NotNull().WithMessage("IsEnabled is required.");
            RuleFor(v => v.KeepOriginImage)
                .NotNull().WithMessage("KeepOriginImage is required.");
            RuleFor(v => v.FontSize)
                .NotNull().WithMessage("FontSize is required.");
            RuleFor(v => v.WatermarkText)
                .NotEmpty().WithMessage("WatermarkText is required.")
                .MaximumLength(32).WithMessage("WatermarkText must not exceed 32 characters.");
        }
    }
}