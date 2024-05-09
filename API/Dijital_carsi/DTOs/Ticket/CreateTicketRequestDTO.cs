using Core.Entities.Domains;

namespace Dijital_carsi.DTOs.Ticket
{
    public class CreateTicketRequestDTO
    {
        public string Description { get; set; }
        public string TicketContext { get; set; }
        public string CustomerUserId { get; set; } 
    }
}
