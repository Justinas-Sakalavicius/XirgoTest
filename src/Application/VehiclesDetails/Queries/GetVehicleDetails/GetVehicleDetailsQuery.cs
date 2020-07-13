using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;

namespace XirgoTest.Application.VehicleDetails.Queries.GetVehicleDetails
{
    public class GetVehicleDetailsQuery : IRequest<VehicleDetailsVm>
    {
        public long VehicleId { get; set; }
    }

    public class GetVehicleDetailsQueryHandler : IRequestHandler<GetVehicleDetailsQuery, VehicleDetailsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVehicleDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VehicleDetailsVm> Handle(GetVehicleDetailsQuery request, CancellationToken cancellationToken)
        {
            return new VehicleDetailsVm
            {
                VehicleDetails = await _context.VehiclesDetails
                    .Where(detail => detail.VechileId == request.VehicleId)
                    .ProjectTo<VehicleDetailsDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Id)
                    .Take(10)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
