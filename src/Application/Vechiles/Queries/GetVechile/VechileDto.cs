using XirgoTest.Application.Common.Mappings;
using XirgoTest.Domain.Entities;

namespace XirgoTest.Application.Vechiles.Queries.GetVechile
{
    public class VechileDto : IMapFrom<Vechile>
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
    }
}
