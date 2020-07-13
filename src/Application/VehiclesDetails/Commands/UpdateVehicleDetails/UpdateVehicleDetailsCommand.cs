using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.VehicleDetails.Commands.UpdateVehicleDetails
{
    public class UpdateVehicleDetailsCommand : IRequest<long>
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
    }

    public class UpdateVehicleDetailsCommandHandler : IRequestHandler<UpdateVehicleDetailsCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVehicleDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(UpdateVehicleDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehiclesDetails.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(VehicleDetail), request.Id);
            }

            entity.Latitude = request.Latitude;
            entity.Longitude = request.Longitude;
            entity.Speed = request.Speed;

            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
