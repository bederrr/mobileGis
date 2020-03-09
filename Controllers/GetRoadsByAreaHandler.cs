using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gis.Models;
using Gis.Models.DB;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
            var param = new SqlParameter("@str", "POLYGON((-88 34,-87 32, -87 32, -87 34, -88 34))");

            var result = await _webGisContext.Roads.FromSqlRaw("GetByArea @str", param)
                .ToListAsync(cancellationToken);
            
            return result.Select(x => new MyModelDto {Id = x.Id}).ToList();
        }
    }
}