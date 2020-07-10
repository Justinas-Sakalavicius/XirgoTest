using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;

namespace XirgoTest.Application.Vechiles.Queries.GetVechileList
{
    public class GetVechilesQuery : IRequest<VechilesVm>
    {
    }

    public class GetVechileQueryHandler : IRequestHandler<GetVechilesQuery, VechilesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVechileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VechilesVm> Handle(GetVechilesQuery request, CancellationToken cancellationToken)
        {
            return new VechilesVm
            {
                Vechiles = await _context.Vechiles
                    .ProjectTo<VechilesDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Id)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
