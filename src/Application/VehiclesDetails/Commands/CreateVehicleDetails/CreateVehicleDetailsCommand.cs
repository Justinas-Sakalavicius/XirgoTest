using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.VehicleDetails.Commands.CreateVehicleDetails
{
    public class CreateVehicleDetailsCommand : IRequest<long>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
        public int VehicleId { get; set; }
    }
    
    public class CreateVechileDetailsCommandHandler : IRequestHandler<CreateVehicleDetailsCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public CreateVechileDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateVehicleDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = new VehicleDetail
            {
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Speed = request.Speed,
                VechileId = request.VehicleId
            };

            _context.VehiclesDetails.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
