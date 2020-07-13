using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Vehicles.Commands.CreateVehicle;
using XirgoTest.Application.Vehicles.Commands.UpdateVehicle;
using XirgoTest.Domain.Entities;

namespace Application.IntegrationTests.Vechiles.Commands
{
    using static Testing;
    public class UpdateVechileTests : TestBase
    {
        [Test]
        public void ShouldRequireValidVechileId()
        {
            var command = new UpdateVehicleCommand
            {
                Id = 99,
                LicensePlate = "CCO056",
                BrandName = "Opel",
                ModelName = "Astra",
                colorName = "Green"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldRequireUniqueLicensePlate()
        {
            var vechileId = await SendAsync(new CreateVehicleCommand
            {
                LicensePlate = "CCO056",
                BrandName = "Opel",
                ModelName = "Astra",
                Color = "Green"
            });

            await SendAsync(new CreateVehicleCommand
            {
                LicensePlate = "AAA000",
                BrandName = "VW",
                ModelName = "Golf",
                Color = "Silver"
            });

            var command = new UpdateVehicleCommand
            {
                Id = vechileId,
                LicensePlate = "AAA000",
                BrandName = "VW",
                ModelName = "Golf",
                colorName = "Silver"
            };

            FluentActions.Invoking(() =>
                SendAsync(command))
                    .Should().Throw<ValidationException>().Where(ex => ex.Errors.ContainsKey("LicensePlate"))
                    .And.Errors["LicensePlate"].Should().Contain("The specified license plate number already exists.");
        }

        [Test]
        public async Task ShouldUpdateVechile()
        {
            var vechileId = await SendAsync(new CreateVehicleCommand
            {
                LicensePlate = "AAA000",
                BrandName = "VW",
                ModelName = "Golf",
                Color = "Silver"
            });

            var command = new UpdateVehicleCommand
            {
                Id = vechileId,
                LicensePlate = "CCO056",
                BrandName = "Opel",
                ModelName = "Astra",
                colorName = "Green"
            };

            await SendAsync(command);

            var list = await FindAsync<Vehicle>(vechileId);

            list.LicensePlate.Should().Be(command.LicensePlate);
            list.BrandName.Should().Be(command.BrandName);
            list.ModelName.Should().Be(command.ModelName);
            list.Color.Should().Be(command.colorName);
        }
    }
}
