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
        public IActionResult Get()
        {
            return Ok(new string[] {"Laptop","Model", "Mobile Phone", "Pencil", "NoteBook", "Brush"});
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new string[] {"Pencil", "NoteBook", "Brush"});
        }
    }
}
