using FluentValidation;

namespace BioWorld.Application.Comment.Commands.AddReply
{
    public class AddReplyCommandValidator : AbstractValidator<AddReplyCommand>
    {
        public AddReplyCommandValidator()
        {
            RuleFor(v => v.IpAddress)
                .MaximumLength(64).WithMessage("IpAddress must not exceed 64 characters.")
                .NotEmpty().WithMessage("IpAddress is required.");

            RuleFor(v => v.UserAgent)
                .MaximumLength(512).WithMessage("UserAgent must not exceed 512 characters.")
                .NotEmpty().WithMessage("UserAgent is required.");

            RuleFor(v => v.ReplyContent)
                .NotEmpty().WithMessage("ReplyContent is required.");

            RuleFor(v => v.CommentId)
                .NotEmpty().WithMessage("CommentId is required.");
        }
    }
}