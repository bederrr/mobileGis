using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gis.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace Gis.Controllers
{
    public class GetRoadsByAreaHandler : IRequestHandler<GetRoadsByAreaQuery, List<PlaceDto>>
    {
        private readonly WebGisContext webGisContext;

        public GetRoadsByAreaHandler(WebGisContext webGisContext)
        {
            this.webGisContext = webGisContext;
        }

        public async Task<List<PlaceDto>> Handle(GetRoadsByAreaQuery request, CancellationToken cancellationToken)
        {
            var linearRing = new LinearRing(request.Coordinates);

            linearRing = linearRing.IsCCW ? linearRing 
                : linearRing.Reverse() as LinearRing;

            var searchArea = new Polygon(linearRing) { SRID = 4326 };

            var result = await webGisContext.Places
                .Where(x => x.Point.Within(searchArea)).ToListAsync(cancellationToken);
            return result.Select(x => new PlaceDto {Name = x.Name}).ToList();
        }
    }
}