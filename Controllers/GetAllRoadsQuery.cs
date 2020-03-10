using System.Collections.Generic;
using Gis.Models;
using MediatR;

namespace Gis.Controllers
{
    public class GetAllRoadsQuery : IRequest<List<PlaceDto>>
    {
        
    }
}