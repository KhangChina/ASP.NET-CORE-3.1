using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationServices _authenticationService;
        public AuthenticationController(IAuthenticationServices authenticationService)
        {
          
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public IActionResult Post ([FromForm] User user)
        {
            var res = _authenticationService.Autheticate(user.userName, user.userPass);
            if (res == null) return BadRequest(new { message = "User or Pass is incorrect" });
            return Ok(res);

        }
    }
}
