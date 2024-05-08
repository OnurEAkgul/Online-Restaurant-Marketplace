using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {


        //---------------GET----------------

        //GET ALL
        [HttpGet("GetAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            return Ok();

        }

        //GET BY STATUS
        [HttpGet("GetTicketsByStatus/{TicketStatus}")]
        public async Task<IActionResult> GetTicketsByStatus([FromRoute] string TicketStatus)
        {
            return Ok();

        }

        //GET BY SUPPORT USER
        [HttpGet("GetTicketsBySupportUser/{SupportUserId}")]
        public async Task<IActionResult> GetTicketsBySupportUser([FromRoute] string SupportUserId)
        {
            return Ok();

        }

        //GET BY CUSTOMER USER
        [HttpGet("GetTicketsByCustomerUser/{CustomerUserId}")]
        public async Task<IActionResult> GetTicketsByCustomerUser([FromRoute] string CustomerUserId)
        {
            return Ok();

        }

        //GET BY TICKET ID
        [HttpGet("GetTicketById/{TicketId:guid}")]
        public async Task<IActionResult> GetTicketById([FromRoute] Guid TicketId)
        {
            return Ok();

        }


        //---------------POST----------------

        //CREATE TICKET
        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket()
        {
            return Ok();

        }

        //---------------PUT----------------
        
        //UPDATE TICKET
        [HttpPut("UpdateTicket/{TicketId:guid}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] Guid TicketId)
        {
            return Ok();

        }

        //---------------DELETE----------------

        //DELETE TICKET
        [HttpDelete("DeleteTicket/{TicketId:guid}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] Guid TicketId)
        {
            return Ok();

        }





    }
}
