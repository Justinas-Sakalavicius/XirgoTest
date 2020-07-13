using XirgoTest.Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using XirgoTest.Domain.Entities;
using XirgoTest.Application.Vehicles.Commands.CreateVehicle;

namespace Application.IntegrationTests.Vechiles.Commands
{
    using static Testing;
    public class CreateVechileTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateVehicleCommand();

            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldRequireUniqueLicensePlate()
        {
            await SendAsync(new CreateVehicleCommand
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            });

            var command = new CreateVehicleCommand
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            };

            FluentActions.Invoking(() => SendAsync(command))
                .Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateVechile()
        {
            var command = new CreateVehicleCommand
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            };

            var id = await SendAsync(command);

            var vechile = await FindAsync<Vehicle>(id);

            vechile.Should().NotBeNull();
            vechile.LicensePlate.Should().Be(command.LicensePlate);
            vechile.BrandName.Should().Be(command.BrandName);
            vechile.ModelName.Should().Be(command.ModelName);
            vechile.Color.Should().Be(command.Color);
        }
    }
}
