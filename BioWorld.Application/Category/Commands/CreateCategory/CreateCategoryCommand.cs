using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryDto>
    {
        public string RouteName { get; set; }
        public string DisplayName { get; set; }
        public string Note { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryDto>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                RouteName = request.RouteName.Trim(),
                Note = request.Note.Trim(),
                DisplayName = request.DisplayName.Trim()
            };

            await _context.Category.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCategoryDto()
            {
                Id = category.Id,
                RouteName = category.RouteName,
                Note = category.Note,
                DisplayName = category.DisplayName
            };
        }
    }
}