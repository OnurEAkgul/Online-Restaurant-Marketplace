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
        public string Status { get; set; }
        public string SupportUserId { get; set; }
        public SupportUser SupportUser { get; set; }
    }
}
