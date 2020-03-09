using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Gis.Models.DB
{
    public partial class RoadUsChar
    {
        public Geometry RoadGeom { get; set; }
        public int Id { get; set; }
    }
}
