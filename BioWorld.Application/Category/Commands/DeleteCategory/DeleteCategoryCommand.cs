using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // var entity = await _context.Category
            //     .Where(l => l.Id == request.Id)
            //     .AsNoTracking()
            //     .SingleOrDefaultAsync(cancellationToken);
            //
            // if (entity == null)
            // {
            //     throw new NotFoundException(nameof(CategoryEntity), request.Id);
            // }

            var entity = await _context.Category.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CategoryEntity), request.Id);
            }
            
            var pc = await _context.PostCategory
                .Where(l => l.CategoryId == request.Id)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (null != pc)
            {
                _context.PostCategory.RemoveRange(pc);
            }

            _context.Category.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}