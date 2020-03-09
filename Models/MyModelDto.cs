namespace Gis.Models
{
    using System;
    
    public class MyModelDto
    {
        public string Country { get; set; }
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }

}