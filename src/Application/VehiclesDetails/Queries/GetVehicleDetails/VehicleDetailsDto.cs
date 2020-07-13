using XirgoTest.Application.Common.Mappings;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.VehicleDetails.Queries.GetVehicleDetails
{
    public class VehicleDetailsDto : IMapFrom<VehicleDetail>
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
    }
}
