using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {

        [HttpPost("testservice")]
        public async Task<IActionResult> TestService()
        {
            FormFile imageFile = (FormFile) HttpContext.Request.Form.Files[0];
            return Ok();
        }
    }
}
