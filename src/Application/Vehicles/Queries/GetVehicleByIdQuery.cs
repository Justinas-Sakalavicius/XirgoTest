using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;

namespace XirgoTest.Application.Vehicles.Queries
{
    public class GetVehicleByIdQuery : IRequest<VehicleVm>
    {
        public int Id { get; set; }
    }

    public class GetVechileByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVechileByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VehicleVm> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            return new VehicleVm
            {
                Vehicle = await _context.Vehicles
                .ProjectTo<VehiclesDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            };
        }
    }
}
