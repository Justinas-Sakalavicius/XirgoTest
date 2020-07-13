namespace XirgoTest.Domain.Entities
{
    public class VehicleDetail
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }

        public int VechileId { get; set; }
        public Vehicle Vechile { get; set; }
    }
}
