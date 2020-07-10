using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.VechileDetails.Commands.CreateVechileDetails
{
    public class CreateVechileDetailsCommand : IRequest<long>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
        public int VechileId { get; set; }
    }
    
    public class CreateVechileDetailsCommandHandler : IRequestHandler<CreateVechileDetailsCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public CreateVechileDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(CreateVechileDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = new VechileDetail
            {
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Speed = request.Speed,
                VechileId = request.VechileId
            };

            _context.VechileDetails.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
