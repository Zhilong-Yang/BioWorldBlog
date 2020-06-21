using FluentValidation;

namespace BioWorld.Application.Comment.Commands.ApproveComment
{
    public class ApproveToggleCommentCommandValidator : AbstractValidator<ApproveToggleCommentCommand>
    {
        public ApproveToggleCommentCommandValidator()
        {
            RuleFor(v => v.CommentIds)
                .NotEmpty().WithMessage("CommentIds is required.");
        }
    }
}
