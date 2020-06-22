using BioWorld.Application.FriendLink.Commands.AddFriendLink;
using FluentValidation;

namespace BioWorld.Application.FriendLink.Commands.UpdateFriendLink
{
    public class UpdateFriendLinkCommandValidator:AbstractValidator<AddFriendLinkCommand>
    {
        public UpdateFriendLinkCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(64).WithMessage("Title must not exceed 64 characters.");

            RuleFor(v => v.LinkUrl)
                .NotEmpty().WithMessage("LinkUrl is required.")
                .MaximumLength(256).WithMessage("LinkUrl must not exceed 256 characters.");
        }
    }
}
