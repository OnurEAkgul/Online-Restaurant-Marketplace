using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {



        //GET

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok();

        }

        [HttpGet("GetProductById/{id:guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id)
        {
            return Ok();

        }

        [HttpGet("GetProductsByName/{name}")]
        public async Task<IActionResult> GetProductsByName([FromRoute] string name)
        {
            return Ok();

        }

        [HttpGet("GetProductsByCategory/{id:Guid}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] Guid id)
        {
            return Ok();

        }

        [HttpGet("GetProductsByCategoryName/{name}")]
        public async Task<IActionResult> GetProductsByCategoryName([FromRoute] string name)
        {
            return Ok();

        }


        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            return Ok();

        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct()
        {
            return Ok();

        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct()
        {
            return Ok();

        }








    }
}
