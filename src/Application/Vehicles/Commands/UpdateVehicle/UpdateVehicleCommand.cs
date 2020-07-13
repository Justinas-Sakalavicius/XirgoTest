using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Vehicles.Commands.UpdateVehicle
{
    public class UpdateVehicleCommand : IRequest
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string colorName { get; set; }
    }

    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVehicleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vehicles.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Vehicle), request.Id);
            }

            entity.LicensePlate = request.LicensePlate;
            entity.BrandName = request.BrandName;
            entity.ModelName = request.ModelName;
            entity.Color = request.colorName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
