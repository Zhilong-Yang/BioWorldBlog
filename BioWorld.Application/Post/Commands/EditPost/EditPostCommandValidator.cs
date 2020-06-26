using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Post.Commands.EditPost
{
    public class EditPostCommandValidator : AbstractValidator<EditPostCommand>
    {
        private readonly IApplicationDbContext _context;

        public EditPostCommandValidator(IApplicationDbContext context)
        {
            _context = context;


            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(128).WithMessage("Title must not exceed 128 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified Title already exists.");

            RuleFor(v => v.Slug)
                .MaximumLength(128).WithMessage("Slug must not exceed 128 characters.")
                .Matches(@"^[a-z0-9\-]+$").WithMessage("Only lower case letters and hyphens are allowed.")
                .NotEmpty().WithMessage("Slug is required.");

            RuleFor(v => v.ContentLanguageCode)
                .MaximumLength(8).WithMessage("ContentLanguageCode must not exceed 8 characters.")
                .Matches(@"^[a-z]{2}-[a-zA-Z]{2}$").WithMessage("Incorrect language code format. e.g. en-us")
                .NotEmpty().WithMessage("ContentLanguageCode is required.");

            RuleFor(v => v.RequestIp)
                .MaximumLength(64).WithMessage("RequestIp must not exceed 64 characters.")
                .NotEmpty().WithMessage("RequestIp is required.");

            RuleFor(v => v.Tags)
                .NotNull().WithMessage("Tags is required.");

            RuleFor(v => v.CategoryIds)
                .NotNull().WithMessage("CategoryIds is required.");

            RuleFor(v => v.EnableComment)
                .NotNull().WithMessage("EnableComment is required.");

            RuleFor(v => v.IsPublished)
                .NotNull().WithMessage("IsPublished is required.");

            RuleFor(v => v.EditorContent)
                .NotEmpty().WithMessage("EditorContent is required.");
        }

        private async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.Post.AllAsync(c => c.Title != title, cancellationToken);
        }
    }
}