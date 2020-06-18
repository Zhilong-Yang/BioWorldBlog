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

        public CreateCategoryCommandValidator()
        {
            RuleFor(v => v.RouteName)
                .MaximumLength(64).WithMessage("RouteName must not exceed 64 characters.")
                .NotEmpty().WithMessage("RouteName is required.")
                .MustAsync(BeUniqueRouteName).WithMessage("The specified RouteName already exists.");
            ;

            RuleFor(v => v.DisplayName)
                .MaximumLength(64).WithMessage("DisplayName must not exceed 64 characters.")
                .NotEmpty().WithMessage("DisplayName is required.");

            RuleFor(v => v.Note)
                .MaximumLength(128).WithMessage("Note must not exceed 128 characters.")
                .NotEmpty().WithMessage("Note is required.");
        }

        private async Task<bool> BeUniqueRouteName(CreateCategoryCommand model, string name,
            CancellationToken cancellationToken)
        {
            return await _context.Category.AnyAsync(p => p.RouteName != name, cancellationToken);
        }
    }
}