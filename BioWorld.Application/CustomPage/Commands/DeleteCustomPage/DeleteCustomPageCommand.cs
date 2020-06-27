using System;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;

namespace BioWorld.Application.CustomPage.Commands.DeleteCustomPage
{
    public class DeleteCustomPageCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteMenuCommandHandler : IRequestHandler<DeleteCustomPageCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMenuCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomPageCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.CustomPage.FindAsync(request.Id);

            if (null != item)
            {
                _context.CustomPage.Remove(item);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}