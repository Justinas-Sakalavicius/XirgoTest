using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Vechiles.DeleteVechile
{
    public class DeleteVechileCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteVechileCommandHandler : IRequestHandler<DeleteVechileCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVechileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteVechileCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vechiles
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Vechile), request.Id);
            }

            _context.Vechiles.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
