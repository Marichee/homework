using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpPost("addTicket")]
        public IActionResult AddTicket([FromBody]TicketModel model)
        {
            model.UserId = GetAuthorizedUserId();
            var addTicket = _ticketService.AddTicket(model);
            if (addTicket == false) { return NotFound("Invalid input ! Pleace choose 7 different numbers from 1 to 37"); }
            else { return Ok("Ticket is addet"); }
        }
        [HttpGet]
        public ActionResult<IEnumerable<TicketModel>> GetUserTickets()
        {
            var userId = GetAuthorizedUserId();
            return Ok(_ticketService.GetUserTickets(userId));
        }
        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value,
                out var userId))
            {
                throw new Exception("Name identifier claim does not exist.");
            }
            return userId;
        }
    }
}