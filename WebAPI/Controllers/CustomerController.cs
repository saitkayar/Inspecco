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
        private readonly IInvitationService _customerService;

        public CustomerController(IInvitationService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_customerService.GetAll());
        }

        [HttpGet("getone")]
        public IActionResult Get(int id)
        {

            return Ok(_customerService.Get(x=>x.Id==id));
        }
        [HttpPost]
        public IActionResult Add(Customer customer  )
        {
            return Ok(_customerService.Add(customer));
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            return Ok(_customerService.Update(customer));
        }
        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            return Ok(_customerService.Delete(customer));
        }
    }
}
