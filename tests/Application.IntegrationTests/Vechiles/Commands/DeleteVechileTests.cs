using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XirgoTest.Application.Common.Exceptions;
using XirgoTest.Application.Vechiles.CreateVechile;
using XirgoTest.Application.Vechiles.DeleteVechile;
using XirgoTest.Domain.Entities;

namespace Application.IntegrationTests.Vechiles.Commands
{
    using static Testing;
    public class DeleteVechileTests : TestBase
    {
        [Test]
        public void ShouldRequireValidVechilesId()
        {
            var command = new DeleteVechileCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteVechile()
        {
            var vechileId = await SendAsync(new CreateVechileCommand
            {
                LicensePlate = "ABC001",
                BrandName = "Ford",
                ModelName = "Focus",
                Color = "Silver"
            });

            await SendAsync(new DeleteVechileCommand
            {
                Id = vechileId
            });

            var list = await FindAsync<Vechile>(vechileId);

            list.Should().BeNull();
        }
    }
}
