using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using Core.Utilities.Results;
using Dijital_carsi.DTOs.Common;
using Dijital_carsi.DTOs.ShoppingCart;
using Dijital_carsi.DTOs.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {


        private readonly InterfaceTicketService _TicketService;

        public TicketsController(InterfaceTicketService TicketService)
        {
            _TicketService = TicketService;
        }

        //---------------GET----------------

        //GET ALL
        [HttpGet("GetAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            try
            {
                var result = await _TicketService.GetAllTickets();

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Ticket => new TicketsInfoDTO
                {
                    CustomerUserId = Ticket.CustomerUserId,
                    Description = Ticket.Description,
                    Id = Ticket.Id,
                    isActive = Ticket.IsActive,
                    SupportUserId = Ticket.SupportUserId,
                    TicketContext = Ticket.TicketContext,
                    TicketContextResponse = Ticket.TicketContextResponse


                }).ToList();


                var response = new CommonResponseDTO<List<TicketsInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //GET BY STATUS
        [HttpGet("GetTicketsByStatus/{TicketStatus}")]
        public async Task<IActionResult> GetTicketsByStatus([FromRoute] bool TicketStatus)
        {
            try
            {
                var result = await _TicketService.GetTicketsByStatus(TicketStatus);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Ticket => new TicketsInfoDTO
                {
                    CustomerUserId = Ticket.CustomerUserId,
                    Description = Ticket.Description,
                    Id = Ticket.Id,
                    isActive = Ticket.IsActive,
                    SupportUserId = Ticket.SupportUserId,
                    TicketContext = Ticket.TicketContext,
                    TicketContextResponse = Ticket.TicketContextResponse

                }).ToList();


                var response = new CommonResponseDTO<List<TicketsInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        [HttpGet("GetActiveTickets")]
        public async Task<IActionResult> GetActiveTickets()
        {
            try
            {
                var result = await _TicketService.GetTicketsByStatus(true);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Ticket => new TicketsInfoDTO
                {
                    CustomerUserId = Ticket.CustomerUserId,
                    Description = Ticket.Description,
                    Id = Ticket.Id,
                    isActive = Ticket.IsActive,
                    SupportUserId = Ticket.SupportUserId,
                    TicketContext = Ticket.TicketContext,
                    TicketContextResponse = Ticket.TicketContextResponse

                }).ToList();


                var response = new CommonResponseDTO<List<TicketsInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        [HttpGet("GetNotActiveTickets")]
        public async Task<IActionResult> GetNotActiveTickets()
        {
            try
            {
                var result = await _TicketService.GetTicketsByStatus(false);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Ticket => new TicketsInfoDTO
                {
                    CustomerUserId = Ticket.CustomerUserId,
                    Description = Ticket.Description,
                    Id = Ticket.Id,
                    isActive = Ticket.IsActive,
                    SupportUserId = Ticket.SupportUserId,
                    TicketContext = Ticket.TicketContext,
                    TicketContextResponse = Ticket.TicketContextResponse

                }).ToList();


                var response = new CommonResponseDTO<List<TicketsInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //GET BY SUPPORT USER
        [HttpGet("GetTicketsBySupportUser/{SupportUserId}")]
        public async Task<IActionResult> GetTicketsBySupportUser([FromRoute] string SupportUserId)
        {
            try
            {
                var result = await _TicketService.GetTicketsBySupportUser(SupportUserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Ticket => new TicketsInfoDTO
                {
                    CustomerUserId = Ticket.CustomerUserId,
                    Description = Ticket.Description,
                    Id = Ticket.Id,
                    isActive = Ticket.IsActive,
                    SupportUserId = Ticket.SupportUserId,
                    TicketContext = Ticket.TicketContext,
                    TicketContextResponse = Ticket.TicketContextResponse


                }).ToList();


                var response = new CommonResponseDTO<List<TicketsInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //GET BY CUSTOMER USER
        [HttpGet("GetTicketsByCustomerUser/{CustomerUserId}")]
        public async Task<IActionResult> GetTicketsByCustomerUser([FromRoute] string CustomerUserId)
        {
            try
            {
                var result = await _TicketService.GetTicketsByCustomerUser(CustomerUserId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Ticket => new TicketsInfoDTO
                {
                    CustomerUserId = Ticket.CustomerUserId,
                    Description = Ticket.Description,
                    Id = Ticket.Id,
                    isActive = Ticket.IsActive,
                    SupportUserId = Ticket.SupportUserId,
                    TicketContext = Ticket.TicketContext,
                    TicketContextResponse = Ticket.TicketContextResponse


                }).ToList();


                var response = new CommonResponseDTO<List<TicketsInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //GET BY TICKET ID
        [HttpGet("GetTicketById/{TicketId:guid}")]
        public async Task<IActionResult> GetTicketById([FromRoute] Guid TicketId)
        {
            try
            {
                var result = await _TicketService.GetTicketById(TicketId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = new TicketsInfoDTO
                {
                    CustomerUserId = result.Data.CustomerUserId,
                    Description = result.Data.Description,
                    Id = result.Data.Id,
                    isActive = result.Data.IsActive,
                    SupportUserId = result.Data.SupportUserId,
                    TicketContext = result.Data.TicketContext,
                    TicketContextResponse = result.Data.TicketContextResponse


                };


                var response = new CommonResponseDTO<TicketsInfoDTO>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }


        //---------------POST----------------

        //CREATE TICKET
        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket(CreateTicketRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }


                var CreateRequest = new Ticket
                {
                    CustomerUserId = request.CustomerUserId,
                    Description = request.Description,
                    TicketContext = request.TicketContext,
                    IsActive=true

                };

                var result = await _TicketService.CreateTicket(CreateRequest);

                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //---------------PUT----------------

        //UPDATE TICKET
        [HttpPut("UpdateTicket/{TicketId:guid}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] Guid TicketId, TicketUpdateRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }


                var UpdateRequest = new Ticket
                {
                    Id = TicketId,
                    IsActive = request.isActive,
                    SupportUserId = request.SupportUserId,
                    CustomerUserId = request.CustomerUserId,
                    Description = request.Description,
                    TicketContext = request.TicketContext,
                    TicketContextResponse = request.TicketContextResponse
                };

                var result = await _TicketService.UpdateTicket(UpdateRequest);

                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };


        }

        //UPDATE TICKET
        [HttpPut("AssignSupportUser/{TicketId:guid}/{SupportUserId}")]
        public async Task<IActionResult> AssignSupportUser([FromRoute] Guid TicketId, string SupportUserId)
        {
            try
            {
                if (TicketId == null||SupportUserId==null)
                {
                    return BadRequest("Invalid request");
                }

                var result = await _TicketService.AssignSupportUser(TicketId,SupportUserId);

                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };


        }

        //TOGGLE STATUS
        [HttpPut("ToggleTicketStatus/{TicketId:Guid}/{ToggleStatus:bool}")]
        //[Authorize(Roles = "shopOwnerRole")]
        public async Task<IActionResult> ToggleProductStatus([FromRoute] Guid TicketId, bool ToggleStatus)
        {
            try
            {

                var result = await _TicketService.ToggleTicketStatus(TicketId, ToggleStatus);
                if (!result.Success)
                {
                    return BadRequest(result);
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        //---------------DELETE----------------

        //DELETE TICKET
        [HttpDelete("DeleteTicket/{TicketId:guid}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] Guid TicketId)
        {
            try
            {
                if (TicketId == null)
                {
                    return BadRequest("Invalid request");
                }

                var result = await _TicketService.DeleteTicket(TicketId);

                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };
        }

    }
}
