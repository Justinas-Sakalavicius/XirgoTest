using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.VechileDetails.Commands.UpdateVechileDetails
{
    public class UpdateVechileDetailsCommand : IRequest<long>
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
    }

    public class UpdateVechileDetailsCommandHandler : IRequestHandler<UpdateVechileDetailsCommand, long>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVechileDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(UpdateVechileDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VechileDetails.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(VechileDetail), request.Id);
            }

            entity.Latitude = request.Latitude;
            entity.Longitude = request.Longitude;
            entity.Speed = request.Speed;

            await _context.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
