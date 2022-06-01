using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            return Ok(_customerService.GetAll());
        }

        [HttpGet("getone")]
        public IActionResult Get(int id)
        {

            return Ok(_customerService.Get(x=>x.Id==id));
        }
        [HttpPost("ekle")]
        public IActionResult Add(Customer customer  )
        {
            return Ok(_customerService.Add(customer));
        }

        [HttpPut("güncelle")]
        public IActionResult Update(Customer customer)
        {
            return Ok(_customerService.Update(customer));
        }
        [HttpDelete("sil")]
        public IActionResult Delete(Customer customer)
        {
            return Ok(_customerService.Delete(customer));
        }
    }
}
