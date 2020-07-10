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
using XirgoTest.Application.Vechiles.Queries.GetVechile;

namespace XirgoTest.Application.VechileDetails.Queries.GetVechileDetails
{
    public class GetVechileDetailsQuery : IRequest<VechileDetailsVm>
    {
        public long VechileId { get; set; }
    }

    public class GetVechileDetailsQueryHandler : IRequestHandler<GetVechileDetailsQuery, VechileDetailsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVechileDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VechileDetailsVm> Handle(GetVechileDetailsQuery request, CancellationToken cancellationToken)
        {
            return new VechileDetailsVm
            {
                VechileDetails = await _context.VechileDetails
                    .Where(detail => detail.VechileId == request.VechileId)
                    .ProjectTo<VechileDetailsDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Id)
                    .Take(10)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
