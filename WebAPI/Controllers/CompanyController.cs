using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ICustomerService _customerService;
      

        public CompanyController(ICompanyService companyService, ICustomerService customerService)
        {
            _companyService = companyService;
            _customerService = customerService;
         

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_companyService.GetAll());
        }
        [HttpGet("getonlyone")]
        public IActionResult Get(int id)
        {
            return Ok(_companyService.Get(x=>x.Id==id));
        }
        [HttpGet("getbydetail")]
        public IActionResult GetByDetail()
        {
            return Ok(_companyService.GetByDetail());
        }
        [HttpPost("firma ekle")]
        public IActionResult Add(string company)
        {
            var result = new Company()
            {
                CompanyName = company,

            };
            return Ok(_companyService.Add(result));
        }
        [HttpPut("firma güncelle")]
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
        public IActionResult Invite( string customerName)
        {
            var result = _companyService.GetByDetail(x => x.CustomerName == customerName);
            
            if (result.Success)
            {
                _customerService.Get(c => c.CustomerName == customerName).Data.IsInvited=true;
            

             
                return Ok($"{customerName}'e davetiye gönderildi");


            }

            return BadRequest("davet gönderilemedi");
            
        }
    }
}
