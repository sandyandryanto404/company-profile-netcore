
using backend.Models.Entities;
using backend.Models.Requests;
using backend.Models.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Models.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        private readonly AppDbContext _context;

        public UserService(IOptions<AppSettings> appSettings, AppDbContext ctx)
        {
            _appSettings = appSettings.Value;
            _context = ctx;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = (from u in _context.User where u.Username == model.Username || u.Email == model.Username select u).SingleOrDefault();

            // return null if user not found
            if (user == null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return null;
            }

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetById(int id)
        {
            return (from u in _context.User where u.Id == id select u).SingleOrDefault();
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
