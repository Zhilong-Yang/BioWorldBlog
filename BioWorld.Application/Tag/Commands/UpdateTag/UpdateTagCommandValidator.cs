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
                .MustAsync(BeUniqueName).WithMessage("The specified Tag Name already exists.");
        }

        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Tag
                .AllAsync(l => l.DisplayName != name);
        }
    }
}