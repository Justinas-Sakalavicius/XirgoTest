using System.Collections;
using System.Collections.Generic;

namespace XirgoTest.Domain.Entities
{
    public class Vechile 
    {
        public Vechile()
        {
            this.Details = new List<VechileDetail>();
        }

        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }

        public IList<VechileDetail> Details { get; set; }

    }
}
