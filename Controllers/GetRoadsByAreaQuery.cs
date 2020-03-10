using System.Collections.Generic;
using Gis.Models;
using MediatR;
using NetTopologySuite.Geometries;

namespace Gis.Controllers
{
    public class GetRoadsByAreaQuery : IRequest<List<MyModelDto>>
    {
        public Coordinate[] Coordinates { get; }

        public GetRoadsByAreaQuery(double x1, double y1, double x2, double y2)
        {
            Coordinates = new Coordinate[]
            {
                new Coordinate(x1, y1),
                new Coordinate(x2, y1),
                new Coordinate(x2, y2),
                new Coordinate(x1, y2),
                new Coordinate(x1, y1)
            };
        }
    }
}