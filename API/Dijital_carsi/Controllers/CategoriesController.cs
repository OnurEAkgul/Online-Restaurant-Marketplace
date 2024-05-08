using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("GetCategoryById/{id:guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute]Guid id)
        {
            return Ok();

        }
        
        [HttpGet("GetCategoryByName/{name}")]
        public async Task<IActionResult> GetCategoryByName([FromRoute] string name)
        {
            return Ok();

        }
        
        [HttpGet("GetActiveCategories")]
        public async Task<IActionResult> GetActiveCategories()
        {
            return Ok();

        }
        
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok();

        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory()
        {
            return Ok();

        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory()
        {
            return Ok();

        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory()
        {
            return Ok();

        }



    }
}
