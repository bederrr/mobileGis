using System.Collections.Generic;
using Gis.Models;
using MediatR;

namespace Gis.Controllers
{
    public class GetRoadsByAreaQuery : IRequest<List<MyModelDto>>
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public double D { get; }
        
        public GetRoadsByAreaQuery(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
    }
}