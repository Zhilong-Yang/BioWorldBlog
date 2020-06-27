using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;

namespace BioWorld.Application.Menu.Commands.DeleteMenu
{
    public class DeleteMenuCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.Menu.FindAsync(request.Id);

            if (null != item)
            {
                _context.Menu.Remove(item);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}