namespace Gis.Models
{
    using System;
    using NetTopologySuite.Geometries;
    
    public class MyModel
    {
        public string Country { get; set; }
        public Guid Id { get; set; }
        public Point Location { get; set; }
        public string Name { get; set; }
    }
}