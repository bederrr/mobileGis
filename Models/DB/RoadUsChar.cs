using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Gis.Models.DB
{
    public class RoadUsChar
    {
        [NotMapped]
        public Geometry RoadGeom { get; set; }
        public int Id { get; set; }
    }
}
