using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommand : IRequest<int>
    {
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
    }

    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateVehicleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Vehicle
            {
                LicensePlate = request.LicensePlate,
                BrandName = request.BrandName,
                ModelName = request.ModelName,
                Color = request.Color
            };

            _context.Vehicles.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
