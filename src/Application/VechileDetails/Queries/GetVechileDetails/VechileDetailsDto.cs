using XirgoTest.Application.Common.Mappings;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.VechileDetails.Queries.GetVechileDetails
{
    public class VechileDetailsDto : IMapFrom<VechileDetail>
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
    }
}
