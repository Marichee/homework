using DataAccess;
using DataModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDto> _userRepository;
        private readonly ITicketService _ticketService;
        private readonly IOptions<AppSettings> _options;
        public UserService(IRepository<UserDto> userRepository, ITicketService ticketService, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _ticketService = ticketService;
            _options = options;
        }
        public string HashedDataMethod(string word)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(word));
            var hashedData = Encoding.ASCII.GetString(md5Data);
            return hashedData;
        }

        public UserModel LogIn(string username, string password)
        {
            var user = _userRepository.GetAll().SingleOrDefault(x => x.Username == username && x.Password == HashedDataMethod(password));
            if (user == null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name,
                        $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier,
                        user.Id.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            UserModel userModel = new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = (Role)user.Role,
                Email = user.Email,
                Username = user.FirstName,
                Token = tokenHandler.WriteToken(token)
            };

            return userModel;
        }
        public void Register(RegisterModel model)
        {
            UserDto user = new UserDto()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Username = model.Username,
                Password = HashedDataMethod(model.Password),
                Role = 2
            };
            _userRepository.Add(user);

        }
        public RegisterModel CheckUsername(RegisterModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == model.Username);
            if (user != null) return model;
            return null;
        }
        public RegisterModel GetUser(int id)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Id == id);
            return new RegisterModel()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = (Role)user.Role
            };
        }
    }
}
