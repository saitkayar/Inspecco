using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompanyService _companyService;

        public HomeController(ILogger<HomeController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
         ViewBag.company= _companyService.GetAll().Data;
          _logger.LogDebug("ürünler geldi");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}