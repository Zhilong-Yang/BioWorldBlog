using FluentValidation;

namespace BioWorld.Application.Setting.Commands.UpdateAdvanceSetting
{
    public class UpdateAdvanceSettingCommandValidator : AbstractValidator<UpdateAdvanceSettingCommand>
    {
        public UpdateAdvanceSettingCommandValidator()
        {
            RuleFor(v => v.DNSPrefetchEndpoint)
                .Matches(@"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?") // URL Regex
                .MaximumLength(128).WithMessage("DNSPrefetchEndpoint must not exceed 128 characters.");

            RuleFor(v => v.RobotsTxtContent)
                .MaximumLength(1024).WithMessage("RobotsTxtContent must not exceed 1024 characters.");
        }
    }
}