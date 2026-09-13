using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using zesty_api.Data;
using zesty_api.Data.Entities;
using zesty_api.Interfaces;
using zesty_api.Models;

namespace zesty_api.Services;

public abstract class AuthService(DataContext db, IConfiguration configuration) : IAuthService
{
    public string Login(LoginUser requestUser)
    {
        var checkUser = db.Users.FirstOrDefault(u => u.Username == requestUser.Username);
        if (checkUser == null || !BCrypt.Net.BCrypt.Verify(requestUser.Password, checkUser.Password))
            throw new Exception("Username or password is incorrect");

        var token = CreateToken(MapToDto(checkUser));
        return token;
    }

    public User Register(User user)
    {
        var existingUser = db.Users.FirstOrDefault(u => u.Username == user.Username || u.Email == user.Email);
        if (existingUser != null) throw new Exception("Username or email already in use");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        var userEntity = UserEntity.Create(user.Username ?? throw new InvalidOperationException("Username is empty!"),
            user.Email, passwordHash);
        db.Users.Add(userEntity);
        db.SaveChanges();
        user.Id = userEntity.Id;

        return MapToDto(userEntity);
    }

    private static User MapToDto(UserEntity entity)
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
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, user.Username ?? throw new InvalidOperationException())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Token").Value!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}