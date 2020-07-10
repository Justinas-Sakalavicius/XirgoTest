using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;

namespace XirgoTest.Application.Vechiles.Queries.GetVechile
{
    public class GetVechileByIdQuery : IRequest<VechileVm>
    {
        public int Id { get; set; }
    }

    public class GetVechileByIdQueryHandler : IRequestHandler<GetVechileByIdQuery, VechileVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVechileByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VechileVm> Handle(GetVechileByIdQuery request, CancellationToken cancellationToken)
        {
            return new VechileVm
            {
                Vechile = await _context.Vechiles
                .ProjectTo<VechileDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken)
            };
        }
    }
}
