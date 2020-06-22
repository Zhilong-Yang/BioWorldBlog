using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.FriendLink.Commands.AddFriendLink
{
    public class AddFriendLinkCommandValidator : AbstractValidator<AddFriendLinkCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddFriendLinkCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(64).WithMessage("Title must not exceed 64 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified Title already exists.");

            RuleFor(v => v.LinkUrl)
                .NotEmpty().WithMessage("LinkUrl is required.")
                .MaximumLength(256).WithMessage("LinkUrl must not exceed 256 characters.")
                .MustAsync(BeUniqueLinkUrl).WithMessage("The specified LinkUrl already exists.");
        }

        private async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.FriendLink.AllAsync(c => c.Title != title, cancellationToken);
        }

        private async Task<bool> BeUniqueLinkUrl(string url, CancellationToken cancellationToken)
        {
            return await _context.FriendLink.AllAsync(c => c.LinkUrl != url, cancellationToken);
        }
    }
}
