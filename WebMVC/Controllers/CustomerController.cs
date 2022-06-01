using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Linq.Expressions;

namespace WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
           ViewBag.customers= _customerService.GetAll();
            return View();
        }
        public IActionResult Invited()
        {
            ViewBag.customers = _customerService.GetAll().Data.Where(x=>x.IsInvited==true);
            return View();
        }
    }
}
