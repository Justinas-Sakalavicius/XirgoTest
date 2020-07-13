using System.Collections;
using System.Collections.Generic;

namespace XirgoTest.Domain.Entities
{
    public class Vehicle 
    {
        public Vehicle()
        {
            this.Details = new List<VehicleDetail>();
        }

        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }

        public IList<VehicleDetail> Details { get; set; }

    }
}
