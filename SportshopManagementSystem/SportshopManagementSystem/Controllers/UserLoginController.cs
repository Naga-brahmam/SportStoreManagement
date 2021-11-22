using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportshopManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportshopManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            //Simulated login
            return Ok(new { status = true });
        }
    }
}
