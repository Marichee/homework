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

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ISessionService _sessionSrevice;
        private readonly IUserService _userService;
        public AdminController(ISessionService sessionService, IUserService userService)
        {
            _sessionSrevice = sessionService;
            _userService = userService;
        }

        [HttpPost("StartSession")]
        public IActionResult StartSession()
        {
            var userId = GetAuthorizedUserId();
            var user = _userService.GetUser(userId);
            if (user.Role == Role.Admin)
            {
                _sessionSrevice.StartSession();
                return Ok("ok");
            }
            return NotFound("Only admin can access this");

        }
        [HttpGet]
        public ActionResult<IEnumerable<SessionModel>> GetSessions()
        {
            var userId = GetAuthorizedUserId();
            return Ok(_sessionSrevice.GetAllSeassons());
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