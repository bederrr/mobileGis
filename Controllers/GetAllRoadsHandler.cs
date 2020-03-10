using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gis.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gis.Controllers
{
    using System.Linq;

    public class GetAllRoadsHandler : IRequestHandler<GetAllRoadsQuery, List<PlaceDto>>
    {
        private readonly WebGisContext webGisContext;
        
        public GetAllRoadsHandler(WebGisContext webGisContext)
        {
            this.webGisContext = webGisContext;
        }
        
        public async Task<List<PlaceDto>> Handle(GetAllRoadsQuery request, CancellationToken cancellationToken)
        {
            var data = await webGisContext.Places.ToListAsync(cancellationToken: cancellationToken);

            return data.Select(x => new PlaceDto { Name = x.Name }).ToList();
        }
    }
}