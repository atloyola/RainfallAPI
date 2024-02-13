namespace RainfallApi.Domain.Entities
{
    public class Station
    {        
        public double Easting { get; set; }
        public string? GridReference { get; set; }
        public string? Label { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public Measure[]? Measures { get; set; }
        public double Northing { get; set; }
        public string? Notation { get; set; }
        public string? StationReference { get; set; }
        
    }
}
