using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using zesty_api.Data;
using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext db;

        public AuthService(DataContext db, IConfiguration configuration)
        {
            this._configuration = configuration;
            this.db = db;
        }

        public string Login(LoginUser requestUser)
        {
            var checkUser = db.Users.FirstOrDefault(u => u.Username == requestUser.Username);
            if (checkUser == null)
            {
                throw new Exception("Username or password is incorrect");
            }

            if (!BCrypt.Net.BCrypt.Verify(requestUser.Password, checkUser.Password))
            {
                throw new Exception("Username or password is incorrect");
            }

            string token = CreateToken(MapToDTO(checkUser));
            return token;
        }

        public User Register(User user)
        {
            var existingUser = db.Users.FirstOrDefault(u => u.Username == user.Username || u.Email == user.Email);
            if (existingUser != null)
            {
                throw new Exception("Username or email already in use");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var userEntity = UserEntity.Create(user.Username, user.Email, passwordHash);
            db.Users.Add(userEntity);
            db.SaveChanges();
            user.Id = userEntity.Id;
            return MapToDTO(userEntity);
        }

        public static User MapToDTO(UserEntity entity)
        {
            return new User
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password
            };
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
