using Business.Abstract;

using Core.Extensions;

using Core.Utilities.Results;

using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //Controller path
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       
        private IAuthService _authService;
  
        public AuthController(IAuthService authService)
        {
            _authService = authService;
          
          
        }
        //EndPoint path
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto register)
        {
            var result = _authService.Register(register);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
          
           
            return Ok(result);
        }
      
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto loginDto)
        {
            var loginResult = _authService.Login(loginDto);
            if (!loginResult.Success)
            {
                return BadRequest(loginResult.Message);
            }
            var token = _authService.CreateAccessToken(loginResult.Data);
            return Ok(token);
        }
      
    }
}
