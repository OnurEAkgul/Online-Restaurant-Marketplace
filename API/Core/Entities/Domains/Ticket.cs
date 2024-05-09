using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Domains
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string? SupportUserId { get; set; }
        public SupportUser? SupportUser { get; set; }
        public string TicketContext { get; set; }
        public string? TicketContextResponse{ get; set; }
        public string CustomerUserId { get; set; } // Foreign key to NormalUser (or customer user)
        public NormalUser CustomerUser { get; set; } // Navigation property to NormalUser (or customer user)
    }
}
