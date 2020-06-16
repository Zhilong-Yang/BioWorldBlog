using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Exceptions;
using BioWorld.Application.Common.Interface;
using BioWorld.Application.Core;
using BioWorld.Domain.Entities;
using MediatR;

namespace BioWorld.Application.Tag.Commands
{
    public class UpdateTagCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tag.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TagEntity), request.Id);
            }

            entity.DisplayName = request.Name;
            entity.NormalizedName = Utils.NormalizeTagName(request.Name);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}