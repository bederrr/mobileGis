using System;
using NetTopologySuite.Geometries;

namespace Gis.Models
{
    public partial class Place
    {
        public Geometry Point { get; set; }
        public string Name { get; set; }
    }
}
