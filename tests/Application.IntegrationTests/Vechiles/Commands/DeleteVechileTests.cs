using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Vehicles.Commands.CreateVehicle;
using XirgoTest.Application.Vehicles.Commands.DeleteVehicle;
using XirgoTest.Domain.Entities;

namespace Application.IntegrationTests.Vechiles.Commands
{
    using static Testing;
    public class DeleteVechileTests : TestBase
    {
        [Test]
        public void ShouldRequireValidVechilesId()
        {
            var command = new DeleteVehicleCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteVechile()
        {
            var vechileId = await SendAsync(new CreateVehicleCommand
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            });

            await SendAsync(new DeleteVehicleCommand
            {
                Id = vechileId
            });

            var list = await FindAsync<Vehicle>(vechileId);

            list.Should().BeNull();
        }
    }
}
