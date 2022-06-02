using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserForLoginDto user)
        {
            var loginResult = _authService.Login(user);
            if (!loginResult.Success)
            {
                return BadRequest(loginResult.Message);
            }
            var token = _authService.CreateAccessToken(loginResult.Data);
            return View(token);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserForRegisterDto user)
        {

            var result = _authService.Register(user);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return View(result);
        }
    }
}
