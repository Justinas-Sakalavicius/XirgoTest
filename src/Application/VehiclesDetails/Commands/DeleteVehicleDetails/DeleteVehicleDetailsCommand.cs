using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.VehicleDetails.Commands.DeleteVehicleDetails
{
    public class DeleteVehicleDetailsCommand : IRequest
    {
        public int VehicleId { get; set; }
    }

    public class DeleteVehicleDetailsCommandHandler : IRequestHandler<DeleteVehicleDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVehicleDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVehicleDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehiclesDetails
                .Where(l => l.VechileId == request.VehicleId)
                .ToListAsync(cancellationToken);
           
            if(entity == null)
            {
                throw new NotFoundException(nameof(VehicleDetail), request.VehicleId);
            }

            _context.VehiclesDetails.RemoveRange(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
