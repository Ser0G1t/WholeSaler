using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WholeSaler.Context;
using WholeSaler.DTO;
using WholeSaler.Entity;
using WholeSaler.Exceptions;
using WholeSaler.IService;
using WholeSaler.JWT;

namespace WholeSaler.Service
{
    public class UserAuthService : IUserAuthService
    {
        private readonly CoreContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthSettings _authSettings;
        private const long ROLE_ID = 1;

        public UserAuthService(CoreContext context, IPasswordHasher<User> passwordHasher, AuthSettings authSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authSettings = authSettings;
        }

        public void RegisterUser(RegisterDTO dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                CompanyName = dto.CompanyName,
                NIP = dto.NIP,
                Country = dto.Country,
                City = dto.City,
                Street = dto.Street,
                Address = dto.Address,
                PostCode = dto.PostCode,
                PhoneNumber = dto.PhoneNumber,
            };
            string hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.Role = _context.roles.Find(ROLE_ID);
            user.Password = hashedPassword;

            _context.users.Add(user);
            _context.SaveChanges();
        }
        public string AuthByJwt(LoginDTO dto)
        {
            var user = _context.users.
                Include(user=>user.Role).
                FirstOrDefault(user=> user.Email == dto.Email);

            if (user is null)
            {
                throw new WrongCredentialsException("Wrong credentials");
            }
            var isPasswordCorrect = _passwordHasher.VerifyHashedPassword(user, user.Password, dto.Password);
           if(isPasswordCorrect==PasswordVerificationResult.Failed)
            {
                throw new WrongCredentialsException("Wrong credentials");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.CompanyName),
                new Claim(ClaimTypes.Role, $"{user.Role.RoleName}"),
                new Claim("NIP", user.NIP)
            };

            var generateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.JwtKey));
            var generateCredentials = new SigningCredentials(generateKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authSettings.JwtIssuer,_authSettings.JwtIssuer, claims,
                expires:expires,
                signingCredentials:generateCredentials);

            var tokenHandler= new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
    }
}
