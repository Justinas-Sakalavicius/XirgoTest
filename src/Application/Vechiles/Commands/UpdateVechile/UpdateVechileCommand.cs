using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Vechiles.UpdateVechile
{
    public class UpdateVechileCommand : IRequest
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string colorName { get; set; }
    }

    public class UpdateVechileCommandHandler : IRequestHandler<UpdateVechileCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVechileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateVechileCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vechiles.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Vechile), request.Id);
            }

            entity.LicensePlate = request.LicensePlate;
            entity.BrandName = request.BrandName;
            entity.ModelName = request.ModelName;
            entity.Color = request.colorName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
