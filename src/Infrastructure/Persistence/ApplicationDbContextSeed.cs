using System.Linq;
using System.Threading.Tasks;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Vehicles.Any())
            {
                context.Vehicles.AddRange(
                    new Vehicle
                    {
                        LicensePlate = "ABC001",
                        BrandName = "Ford",
                        ModelName = "Focus",
                        Color = "Silver"
                    },
                    new Vehicle
                    {
                        LicensePlate = "BMS002",
                        BrandName = "Opel",
                        ModelName = "Astra",
                        Color = "White",
                    },
                    new Vehicle
                    {
                        LicensePlate = "KDA003",
                        BrandName = "BMW",
                        ModelName = "M3",
                        Color = "Black",
                    });
                await context.SaveChangesAsync();
            }

            if (!context.VehiclesDetails.Any())
            {
                context.VehiclesDetails.AddRange(
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 24.016113,
                        Speed = 55,
                        VechileId = 1
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 24.016110,
                        Speed = 50,
                        VechileId = 1
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 24.016108,
                        Speed = 49,
                        VechileId = 1
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 24.016105,
                        Speed = 50,
                        VechileId = 1
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 24.016100,
                        Speed = 48,
                        VechileId = 1
                    },
                    new VehicleDetail
                    {
                        Latitude = 51.172210,
                        Longitude = 20.000000,
                        Speed = 30,
                        VechileId = 2
                    },
                    new VehicleDetail
                    {
                        Latitude = 51.172209,
                        Longitude = 20.000000,
                        Speed = 40,
                        VechileId = 2
                    },
                    new VehicleDetail
                    {
                        Latitude = 51.172208,
                        Longitude = 20.000000,
                        Speed = 35,
                        VechileId = 2
                    },
                    new VehicleDetail
                    {
                        Latitude = 51.172207,
                        Longitude = 20.000001,
                        Speed = 38,
                        VechileId = 2
                    },
                    new VehicleDetail
                    {
                        Latitude = 51.172207,
                        Longitude = 20.000004,
                        Speed = 32,
                        VechileId = 2
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 10.000000,
                        Speed = 80,
                        VechileId = 3
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 10.000005,
                        Speed = 81,
                        VechileId = 3
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 10.000010,
                        Speed = 82,
                        VechileId = 3
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 10.000015,
                        Speed = 83,
                        VechileId = 3
                    },
                    new VehicleDetail
                    {
                        Latitude = 55.141210,
                        Longitude = 10.000022,
                        Speed = 90,
                        VechileId = 3
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
