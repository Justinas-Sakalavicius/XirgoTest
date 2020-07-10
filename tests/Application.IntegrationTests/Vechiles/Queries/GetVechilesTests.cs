using FluentAssertions;
using Namotion.Reflection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XirgoTest.Application.Vechiles.Queries.GetVechile;
using XirgoTest.Application.Vechiles.Queries.GetVechileList;
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
            await AddAsync(new Vechile
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            });

            var query = new GetVechilesQuery();

            //Act
            VechilesVm result = await SendAsync(query);

            //Assert
            result.Should().NotBeNull();
            result.Vechiles.Should().HaveCount(1);
        }

        [Test]
        public async Task ShouldReturnFirstVechile()
        {
            //Arrange
            var car = new Vechile
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            };
            await AddAsync(car);

            var query = new GetVechileByIdQuery { Id = car.Id };

            //Act
            VechileVm result = await SendAsync(query);

            //Assert
            result.Should().NotBeNull();
            //result.Vechile.Should().HasProperty(car.LicensePlate);
        }
    }
}
