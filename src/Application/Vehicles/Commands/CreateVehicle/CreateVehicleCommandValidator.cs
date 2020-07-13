using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;

namespace XirgoTest.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateVehicleCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.LicensePlate)
                .NotEmpty().WithMessage("License plate is required.")
                .Length(6).WithMessage("License plate must not exceed 6 characters")
                .MustAsync(BeUniqueLicensePlate).WithMessage("The specified license plate number already exists.");

            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("Vehicle brand is required.")
                .MaximumLength(40).WithMessage("Vehicle brand shoud not exceed 40 characters");

            RuleFor(x => x.ModelName)
                .NotEmpty().WithMessage("Vehicle model is required.")
                .MaximumLength(40).WithMessage("Vehicle model shoud not exceed 40 characters");
        }

        public async Task<bool> BeUniqueLicensePlate(string licensePlate, CancellationToken cancellationToken)
        {
            return await _context.Vehicles
                .AllAsync(l => l.LicensePlate != licensePlate);
        }
    }
}
