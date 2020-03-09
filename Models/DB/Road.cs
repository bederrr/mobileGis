using NetTopologySuite.Geometries;

namespace Gis.Models.DB
{
    public class Road
    {
        public Geometry RoadGeom { get; set; }
        public int Id { get; set; }
    }
}
