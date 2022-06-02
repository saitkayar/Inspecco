using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly ICustomerService _customerService;

        public CompanyController(ICompanyService companyService, ICustomerService customerService)
        {
            _companyService = companyService;
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.company = _companyService.GetAll().Data;
           
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
           return View();

        }
        [HttpPost]
        public IActionResult Add(Company company)
        {
            _companyService.Add(company);
            return RedirectToAction("Index","Company");

        }
        [HttpGet]    
        public IActionResult Invite()
        {
            ViewBag.customer = _customerService.GetAll().Data.Where(a=>a.IsInvited==false);
            return View();

        }

        [HttpPost("ınviteCustomer")]
        public IActionResult Invite(Customer customer)
        {
            //var result = _companyService.GetByDetail(x => x.CustomerName == customer.CustomerName);

            
           
                _customerService.Get(c => c.CustomerName == customer.CustomerName).Data.IsInvited = true;



               


            

            return RedirectToAction("Invited","Customer");

        }
    }
}
