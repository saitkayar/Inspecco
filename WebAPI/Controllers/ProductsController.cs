using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(this._productService.GetAll());
        }


        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            return Ok(this._productService.Add(product));
        }
        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            return Ok(this._productService.Update(product));
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            
            return Ok(this._productService.Delete(product));
        }
    }
}
