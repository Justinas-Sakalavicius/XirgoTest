using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Interfaces;

namespace XirgoTest.Application.Vechiles.CreateVechile
{
    public class CreateVechileCommandValidator : AbstractValidator<CreateVechileCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateVechileCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.LicensePlate)
                .NotEmpty().WithMessage("License plate is required.")
                .Length(6).WithMessage("License plate must not exceed 6 characters")
                .MustAsync(BeUniqueLicensePlate).WithMessage("The specified license plate number already exists.");

            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("Vechile brand is required.")
                .MaximumLength(40).WithMessage("Vechile brand shoud not exceed 40 characters");

            RuleFor(x => x.ModelName)
                .NotEmpty().WithMessage("Vechile model is required.")
                .MaximumLength(40).WithMessage("Vechile model shoud not exceed 40 characters");
        }

        public async Task<bool> BeUniqueLicensePlate(string licensePlate, CancellationToken cancellationToken)
        {
            return await _context.Vechiles
                .AllAsync(l => l.LicensePlate != licensePlate);
        }
    }
}
