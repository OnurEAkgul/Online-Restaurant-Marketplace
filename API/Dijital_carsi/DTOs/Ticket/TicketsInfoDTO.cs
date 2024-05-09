using Core.Entities.Domains;

namespace Dijital_carsi.DTOs.Ticket
{
    public class TicketsInfoDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public string SupportUserId { get; set; }  // Foreign key to SupportUser
        public string CustomerUserId { get; set; } // Foreign key to NormalUser (or customer user)
        public string TicketContext { get; set; }
        public string TicketContextResponse { get; set; }
    }
}
