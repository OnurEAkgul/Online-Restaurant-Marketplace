using Business.Interfaces;
using Core.Entities.Domains;
using Core.Utilities.Results;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class TicketManager : InterfaceTicketService
    {

        private readonly InterfaceTicketDAL ticketDAL;

        public TicketManager(InterfaceTicketDAL ticketDAL)
        {
            this.ticketDAL = ticketDAL;
        }
        public async Task<IResult> CreateTicket(Ticket ticket)
        {
            try
            {
                await ticketDAL.AddAsync(ticket);
                return new SuccessResult("Ticket created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error creating ticket: {ex.ToString()}");
            }
        }

        public async Task<IResult> UpdateTicket(Ticket ticket)
        {
            try
            {
                await ticketDAL.UpdateAsync(ticket);
                return new SuccessResult("Ticket updated successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error updating ticket: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteTicket(Guid ticketId)
        {
            try
            {
                var ticket = new Ticket()
                { Id = ticketId };

                await ticketDAL.DeleteAsync(ticket);
                return new SuccessResult("Ticket deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error deleting ticket: {ex.Message}");
            }
        }

        public async Task<IDataResult<Ticket>> GetTicketById(Guid ticketId)
        {
            try
            {
                var ticket = await ticketDAL.GetAsync(t => t.Id == ticketId);
                if (ticket == null)
                    return new ErrorDataResult<Ticket>(null,"Ticket not found.");

                return new SuccessDataResult<Ticket>(ticket, "Ticket retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Ticket>(null,$"Error retrieving ticket: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Ticket>>> GetAllTickets()
        {
            try
            {
                var tickets = await ticketDAL.GetAllAsync();
                if (tickets == null || tickets.Count == 0)
                    return new ErrorDataResult<List<Ticket>>(null, "Tickets not found.");

                return new SuccessDataResult<List<Ticket>>(tickets, "All tickets retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Ticket>>(null,$"Error retrieving all tickets: {ex.Message}");
            }
        }



        public async Task<IDataResult<List<Ticket>>> GetTicketsByCustomerUser(string customerUserId)
        {
            try
            {
                var tickets = await ticketDAL.GetAllAsync(t => t.CustomerUserId == customerUserId);

                return new SuccessDataResult<List<Ticket>>(tickets, "Tickets retrieved successfully by customer user.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Ticket>>(null, $"Error retrieving tickets by customer user: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Ticket>>> GetTicketsByStatus(bool isActive)
        {
            try
            {
                var tickets = await ticketDAL.GetAllAsync(t => t.IsActive == isActive);

                return new SuccessDataResult<List<Ticket>>(tickets, "Tickets retrieved successfully by status.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Ticket>>(null,$"Error retrieving tickets by status: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Ticket>>> GetTicketsBySupportUser(string supportUserId)
        {
            try
            {
                var tickets = await ticketDAL.GetAllAsync(t => t.SupportUserId == supportUserId);
                //var tickets = await ticketDal.GetTicketsBySupportUser(supportUserId);
                return new SuccessDataResult<List<Ticket>>(tickets, "Tickets retrieved successfully by support user.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Ticket>>(null,$"Error retrieving tickets by support user: {ex.Message}");
            }
        }

        public async Task<IResult> AssignSupportUser(Guid ticketId, string supportUserId)
        {
            try
            {
                var ticket = await ticketDAL.GetAsync(t => t.Id == ticketId);
                //var ticket = await ticketDAL.GetById(ticketId);
                if (ticket == null)
                    return new ErrorResult("Ticket not found.");

                ticket.SupportUserId = supportUserId;
                await ticketDAL.UpdateAsync(ticket);

                return new SuccessResult("Support user assigned to ticket.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error assigning support user to ticket: {ex.Message}");
            }
        }
    }
}
