using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gis.Models;
using Gis.Models.DB;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gis.Controllers
{
    public class GetAllRoadsHandler : IRequestHandler<GetAllRoadsQuery, List<MyModelDto>>
    {
        private readonly WebGisContext _webGisContext;
        
        public GetAllRoadsHandler(WebGisContext webGisContext)
        {
            _webGisContext = webGisContext;
        }
        
        public async Task<List<MyModelDto>> Handle(GetAllRoadsQuery request, CancellationToken cancellationToken)
        {
            var data = await _webGisContext.Roads.ToListAsync(cancellationToken: cancellationToken);

            return null;
        }
    }
}