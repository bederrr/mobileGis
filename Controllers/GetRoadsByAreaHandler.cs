using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gis.Models;
using Gis.Models.DB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace Gis.Controllers
{
    public class GetRoadsByAreaHandler : IRequestHandler<GetRoadsByAreaQuery, List<MyModelDto>>
    {
        private readonly WebGisContext _webGisContext;

        public GetRoadsByAreaHandler(WebGisContext webGisContext)
        {
            _webGisContext = webGisContext;
        }

        public async Task<List<MyModelDto>> Handle(GetRoadsByAreaQuery request, CancellationToken cancellationToken)
        {
            var linearRing = new LinearRing(request.Coordinates);

            linearRing = linearRing.IsCCW ? linearRing 
                : linearRing.Reverse() as LinearRing;

            var searchArea = new Polygon(linearRing) { SRID = 4326 };

            var result = await _webGisContext.Roads
                .Where(x => x.RoadGeom.Within(searchArea)).ToListAsync(cancellationToken);
            return result.Select(x => new MyModelDto {Id = x.Id}).ToList();
        }
    }
}