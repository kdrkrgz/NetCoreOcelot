using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] {"Laptop","Model", "Mobile Phone"};
        }
    }
}
