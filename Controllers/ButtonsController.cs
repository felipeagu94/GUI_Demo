using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneradorUI_Demo.Modelos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeneradorUI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    public class ButtonsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] ButtonModel model)
        {
            return await model.GenerateView();
        }
    }
}