using AutoMapper;
using NUnit.Framework;
using System;
using XirgoTest.Application.Common.Mappings;
using XirgoTest.Application.VehicleDetails.Queries.GetVehicleDetails;
using XirgoTest.Application.Vehicles.Queries;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(Vehicle), typeof(VehiclesDto))]
        [TestCase(typeof(VehicleDetail), typeof(VehicleDetailsDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
