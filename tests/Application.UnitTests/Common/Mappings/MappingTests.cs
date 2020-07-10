using AutoMapper;
using NUnit.Framework;
using System;
using XirgoTest.Application.Common.Mappings;
using XirgoTest.Application.VechileDetails.Queries.GetVechileDetails;
using XirgoTest.Application.Vechiles.Queries.GetVechile;
using XirgoTest.Application.Vechiles.Queries.GetVechileList;
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
        [TestCase(typeof(Vechile), typeof(VechilesDto))]
        [TestCase(typeof(Vechile), typeof(VechileDto))]
        [TestCase(typeof(VechileDetail), typeof(VechileDetailsDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
