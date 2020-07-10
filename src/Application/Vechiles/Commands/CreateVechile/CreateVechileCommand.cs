using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Vechiles.CreateVechile
{
    public partial class CreateVechileCommand : IRequest<int>
    {
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
    }

    public class CreateVechileCommandHandler : IRequestHandler<CreateVechileCommand, int>
    { 
        private readonly IApplicationDbContext _context;

        public CreateVechileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateVechileCommand request, CancellationToken cancellationToken)
        {
            var entity = new Vechile
            {
                LicensePlate = request.LicensePlate,
                BrandName = request.BrandName,
                ModelName = request.ModelName,
                Color = request.Color
            };

            _context.Vechiles.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
