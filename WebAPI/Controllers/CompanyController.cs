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
        private readonly IInvitationService _ınvitationService;

        public CompanyController(ICompanyService companyService, ICustomerService customerService, IInvitationService ınvitationService)
        {
            _companyService = companyService;
            _customerService = customerService;
            _ınvitationService = ınvitationService;

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
