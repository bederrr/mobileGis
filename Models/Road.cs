using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Gis.Models
{
    public partial class Road
    {
        public Geometry RoadGeom { get; set; }
        public int Id { get; set; }
    }
}
