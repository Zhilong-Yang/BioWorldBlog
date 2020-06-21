using FluentValidation;

namespace BioWorld.Application.Comment.Commands.AddComment
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(128).WithMessage("Email must not exceed 128 characters.")
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(v => v.IpAddress)
                .MaximumLength(64).WithMessage("IpAddress must not exceed 64 characters.")
                .NotEmpty().WithMessage("IpAddress is required.");

            RuleFor(v => v.Username)
                .MaximumLength(64).WithMessage("Username must not exceed 64 characters.")
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(v => v.UserAgent)
                .MaximumLength(512).WithMessage("UserAgent must not exceed 512 characters.")
                .NotEmpty().WithMessage("UserAgent is required.");

            RuleFor(v => v.Content)
                .NotEmpty().WithMessage("Content is required.");

            RuleFor(v => v.PostId)
                .NotEmpty().WithMessage("CategoryIds is required.");
        }
    }
}