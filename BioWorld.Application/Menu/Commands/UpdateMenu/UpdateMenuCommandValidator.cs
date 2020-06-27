using FluentValidation;

namespace BioWorld.Application.Menu.Commands.UpdateMenu
{
    public class UpdateMenuCommandValidator : AbstractValidator<UpdateMenuCommand>
    {
        public UpdateMenuCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(64).WithMessage("Title must not exceed 64 characters.");

            RuleFor(v => v.Url)
                .NotEmpty().WithMessage("Url is required.")
                .MaximumLength(256).WithMessage("Url must not exceed 256 characters.");

            RuleFor(v => v.Icon)
                .NotEmpty().WithMessage("Icon is required.")
                .MaximumLength(64).WithMessage("Icon must not exceed 64 characters.");
        }
    }
}