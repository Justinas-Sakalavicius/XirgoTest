using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using XirgoTest.Application.Vehicles.Queries;
using XirgoTest.Domain.Entities;

namespace Application.IntegrationTests.Vechiles.Queries
{
    using static Testing;
    public class GetVechilesTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllVechiles()
        {
            //Arrange
            await AddAsync(new Vehicle
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            });

            var query = new GetAllVehiclesQuery();

            //Act
            VehiclesVm result = await SendAsync(query);

            //Assert
            result.Should().NotBeNull();
            result.Vehicles.Should().HaveCount(1);
        }

        [Test]
        public async Task ShouldReturnFirstVechile()
        {
            //Arrange
            var car = new Vehicle
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            };
            await AddAsync(car);

            var query = new GetVehicleByIdQuery { Id = car.Id };

            //Act
            VehicleVm result = await SendAsync(query);

            //Assert
            result.Should().NotBeNull();
            //result.Vechile.Should().HasProperty(car.LicensePlate);
        }
    }
}
