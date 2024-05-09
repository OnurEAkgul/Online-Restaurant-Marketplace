using Core.Entities.Domains;

namespace Dijital_carsi.DTOs.Ticket
{
    public class TicketUpdateRequestDTO
    {

        
        public string Description { get; set; }
        public bool isActive { get; set; }
        public string SupportUserId { get; set; }
        public string TicketContext { get; set; }
        public string TicketContextResponse { get; set; }
        public string CustomerUserId { get; set; } // Foreign key to NormalUser (or customer user)



    }
}
