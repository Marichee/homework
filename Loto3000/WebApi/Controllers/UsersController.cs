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

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;
        public UsersController(IUserService userService, ISessionService sessionService)
        {
            _userService = userService;
            _sessionService = sessionService;
        }

        [HttpPost("logIn")]
        public IActionResult LogIn([FromBody] LoginModel model)
        {
            var user = _userService.LogIn(model.Username, model.Password);
            if (user == null) return NotFound("Incorrect username or password");
            return Ok(user);
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var checkUsername = _userService.CheckUsername(model);
            if (checkUsername != null) return NotFound("That username already exist");
            _userService.Register(model);
            return Ok("Successfully registered");
        }
        [Authorize]
        [HttpGet("getWinnerBoard/{sessionid}")]
        public IActionResult GetWinnerBoard(int sessionId)
        {
            var userId = GetAuthorizedUserId();
            var session = _sessionService.GetSessionById(sessionId);
            if (session == null) return NotFound("Session does not exist");
            return Ok(session.WinnerBoard);
        }
        [Authorize]
        [HttpGet("getLastWinnerBoard")]
        public IActionResult GetLastWinnerBoard()
        {
            var userId = GetAuthorizedUserId();
            var lastSession = _sessionService.GetAllSeassons().Last();
            var session = _sessionService.GetSessionById(lastSession.Id);
            return Ok(session.WinnerBoard);
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