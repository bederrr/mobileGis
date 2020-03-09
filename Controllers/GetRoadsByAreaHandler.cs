using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gis.Models;
using MediatR;

namespace Gis.Controllers
{
    public class GetRoadsByAreaHandler : IRequestHandler<GetRoadsByAreaQuery, List<MyModelDto>>
    {
        public Task<List<MyModelDto>> Handle(GetRoadsByAreaQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}