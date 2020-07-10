using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.VechileDetails.Commands.DeleteVechileDetails
{
    public class DeleteVechileDetailsCommand : IRequest
    {
        public int VechileId { get; set; }
    }

    public class DeleteVechileDetailsCommandHandler : IRequestHandler<DeleteVechileDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVechileDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteVechileDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VechileDetails
                .Where(l => l.VechileId == request.VechileId)
                .ToListAsync(cancellationToken);
           
            if(entity == null)
            {
                throw new NotFoundException(nameof(VechileDetail), request.VechileId);
            }

            _context.VechileDetails.RemoveRange(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
