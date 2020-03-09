namespace Gis.Controllers
{
    using System.Collections.Generic;
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    
    [ApiController]
    [Route("[controller]")]
    public class MyModelController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<MyModelDto>> Get()
        {
            return null;
        }
    }
}