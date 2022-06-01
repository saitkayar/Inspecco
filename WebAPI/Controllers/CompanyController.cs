using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_companyService.GetAll());
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            return Ok(_companyService.Get(x=>x.Id==id));
        }
        [HttpGet("getbydetail")]
        public IActionResult GetByDetail()
        {
            return Ok(_companyService.GetByDetail());
        }
        [HttpPost]
        public IActionResult Add(string company)
        {
            var result = new Company()
            {
                CompanyName = company,

            };
            return Ok(_companyService.Add(result));
        }
        [HttpPut]
        public IActionResult Update(Company company)
        {
            return Ok(_companyService.Update(company));
        }
        [HttpDelete]
        public IActionResult Delete(Company company)
        {
            return Ok(_companyService.Delete(company));
        }
        [HttpPost("ınviteCustomer")]
        public IActionResult Invite(Company company)
        {
            return Ok(_companyService.Delete(company));
        }
    }
}
