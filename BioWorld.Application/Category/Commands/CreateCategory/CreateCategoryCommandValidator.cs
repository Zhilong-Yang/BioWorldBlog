using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.RouteName)
                .NotEmpty().WithMessage("RouteName is required.")
                .MaximumLength(64).WithMessage("RouteName must not exceed 64 characters.");

            RuleFor(v => v.DisplayName)
                .MaximumLength(64).WithMessage("DisplayName must not exceed 64 characters.")
                .NotEmpty().WithMessage("DisplayName is required.")
                .MustAsync(BeUniqueDisplayName).WithMessage("The specified DisplayName already exists.");

            RuleFor(v => v.Note)
                .MaximumLength(128).WithMessage("Note must not exceed 128 characters.")
                .NotEmpty().WithMessage("Note is required.");
        }

        private async Task<bool> BeUniqueDisplayName(string name, CancellationToken cancellationToken)
        {
            return await _context.Category.AnyAsync(c => c.DisplayName != name, cancellationToken);
        }
    }
}