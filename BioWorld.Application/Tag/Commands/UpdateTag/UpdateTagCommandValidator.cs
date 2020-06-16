using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Tag.Commands.UpdateTag
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTagCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Tag Name is required.")
                .MaximumLength(50).WithMessage("Tag Name must not exceed 50 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified Tag Name already exists.");
        }

        private async Task<bool> BeUniqueTitle(UpdateTagCommand model, string name, CancellationToken cancellationToken)
        {
            return await _context.Tag
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.DisplayName != name, cancellationToken: cancellationToken);
        }
    }
}