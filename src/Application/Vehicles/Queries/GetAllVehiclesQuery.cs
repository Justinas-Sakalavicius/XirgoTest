using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;

namespace XirgoTest.Application.Vehicles.Queries
{
    public class GetAllVehiclesQuery : IRequest<VehiclesVm>
    {
        
    }

    public class GetVechileQueryHandler : IRequestHandler<GetAllVehiclesQuery, VehiclesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVechileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VehiclesVm> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            return new VehiclesVm
            {
                Vehicles = await _context.Vehicles
                    .ProjectTo<VehiclesDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Id)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
