using backend.Models;
using backend.Models.Entities;
using backend.Models.Requests;
using backend.Models.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private IUserService _userService;
        private readonly AppDbContext _db;

        public AuthController(IUserService userService, AppDbContext db)
        {
            _userService = userService;
            _db = db;
        }

        [HttpPost("login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "These credentials do not match our records." });
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest(new { message = "The field 'Email' can not be empty!" });
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { message = "The field 'Password' can not be empty!" });
            }

            var CheckEmail = _db.User.FirstOrDefault(x => x.Email == model.Email);
            if (CheckEmail != null)
            {
                return BadRequest(new { message = "The email has already been taken.!" });
            }

            String token = System.Guid.NewGuid().ToString();
            User user = new User();
            user.Phone = DateTime.Now.Ticks.ToString();
            user.Email = model.Email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            user.Status = 1;
            user.ConfirmToken = token;
            _db.Add(user);
            _db.SaveChanges();

            return Ok(new { token = token, message = "You need to confirm your account. We have sent you an activation code, please check your email." });
        }

        [HttpGet("confirm/{token}")]
        public IActionResult Confirm(string token)
        {
            var user = _db.User.FirstOrDefault(x => x.ConfirmToken == token && x.Status == 0);
            if (user == null)
            {
                return BadRequest(new { message = "These credentials do not match our records." });
            }

            user.Status = 1;
            user.ConfirmToken = null;
            _db.Update(user);
            _db.SaveChanges();

            return Ok(new { status = true, data = new Object(), message = "Your e-mail is verified. You can now login." });
        }

        [HttpPost("email/forgot")]
        public async Task<IActionResult> EmailForgot([FromBody] ForgotPasswordRequest model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest(new { message = "The field 'Email' can not be empty!" });
            }

            var user = _db.User.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                return BadRequest(new { message = "We can't find a user with that e-mail address." });
            }

            String token = System.Guid.NewGuid().ToString();
            user.ResetToken = token;
            _db.Update(user);
            _db.SaveChanges();

            return Ok(new { status = true, data = token, message = "We have e-mailed your password reset link!" });

        }

        [HttpPost("email/reset/{token}")]
        public IActionResult EmailReset(string token, [FromBody] RegisterRequest model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest(new { message = "The field 'Email' can not be empty!" });
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { message = "The field 'Password' can not be empty!" });
            }

            User user = _db.User.Where(x => x.ResetToken == token && x.Email == model.Email).FirstOrDefault();
            if (user == null)
            {
                return BadRequest(new { message = "We can't find a user with that e-mail address or password reset token is invalid.!" });
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            _db.Update(user);
            _db.SaveChanges();
            return Ok(new { status = true, data = new Object(), message = "Your password has been reset!" });

        }
    }
}
