using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {


        //GET

        [HttpGet("GetAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            return Ok();

        }

        [HttpGet("GetTicketById/{id:guid}")]
        public async Task<IActionResult> GetTicketById([FromRoute] Guid id)
        {
            return Ok();

        }

        [HttpGet("GetTicketsByStatus/{status}")]
        public async Task<IActionResult> GetTicketsByStatus([FromRoute] string status)
        {
            return Ok();

        }

        [HttpGet("GetTicketsBySupportUser/{id}")]
        public async Task<IActionResult> GetTicketsBySupportUser([FromRoute] string id)
        {
            return Ok();

        }

        [HttpGet("GetTicketsByCustomerUser/{id}")]
        public async Task<IActionResult> GetTicketsByCustomerUser([FromRoute] string id)
        {
            return Ok();

        }


        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket()
        {
            return Ok();

        }

        [HttpPut("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket()
        {
            return Ok();

        }

        [HttpDelete("DeleteTicket")]
        public async Task<IActionResult> DeleteTicket()
        {
            return Ok();

        }





    }
}
