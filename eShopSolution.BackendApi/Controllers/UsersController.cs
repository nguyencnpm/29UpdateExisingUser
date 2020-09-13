using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.System.Users;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userServic;
        public UsersController(IUserService userService)
        {
            _userServic = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous] // Chua can login cung goi dc funtion nay
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)// FromForm
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userServic.Authenticate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or Password is incorrect.");
            }
            return Ok(resultToken); //new { token = resultToken } 
        }

        [HttpPost]
        [AllowAnonymous] // Chua can login cung goi dc funtion nay
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)// FromForm
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userServic.Register(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessfull.");
            }
            return Ok();
        }


        // http://localhost/api/users/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var users = await _userServic.GetUsersPaging(request);
            return Ok(users);
        }
    }
}
