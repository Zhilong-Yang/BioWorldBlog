using FluentValidation;

namespace BioWorld.Application.CustomPage.Commands.UpdateCustomPage
{
    class UpdateCustomPageCommandValidator : AbstractValidator<UpdateCustomPageCommand>
    {
        public UpdateCustomPageCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(128).WithMessage("Title must not exceed 128 characters.");

            RuleFor(v => v.Slug)
                .NotEmpty().WithMessage("Slug is required.")
                .MaximumLength(128).WithMessage("Slug must not exceed 128 characters.");

            RuleFor(v => v.MetaDescription)
                .NotEmpty().WithMessage("MetaDescription is required.")
                .MaximumLength(256).WithMessage("MetaDescription must not exceed 256 characters.");
        }
    }
}