using Core.Entities.Domains;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceTicketService
    {
        Task<IResult> CreateTicket(Ticket ticket);
        Task<IResult> UpdateTicket(Ticket ticket);
        Task<IResult> DeleteTicket(Guid ticketId);
        Task<IDataResult<Ticket>> GetTicketById(Guid ticketId);
        Task<IDataResult<List<Ticket>>> GetAllTickets();
        Task<IDataResult<List<Ticket>>> GetTicketsByStatus(bool isActive);
        Task<IDataResult<List<Ticket>>> GetTicketsBySupportUser(string supportUserId);
        Task<IDataResult<List<Ticket>>> GetTicketsByCustomerUser(string customerUserId);
        Task<IResult> AssignSupportUser(Guid ticketId, string supportUserId);
    }
}
