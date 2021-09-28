using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("noAuthorized")]
        public string noAuthorized()
        {
            return "No Authorizition!";
        }
        [Authorize]
        [HttpGet("Authorized")]
        public string Authorized()
        {
            return "Authorized!";
        }
    }
}
