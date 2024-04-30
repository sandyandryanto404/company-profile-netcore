using backend.Models.Services;
using backend.Models;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using backend.Models.Requests;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : Controller
    {
        private IUserService _userService;
        private readonly AppDbContext _db;

        public AccountController(IUserService userService, AppDbContext db)
        {
            _userService = userService;
            _db = db;
        }

        [HttpGet("profile")]
        public IActionResult ProfileInfo()
        {
            var user = (User)this.HttpContext.Items["User"];
            return Ok(new { status = true, data = user, message = "ok" });
        }

        [HttpPost("profile/update")]
        public IActionResult ProfileUpdate([FromBody] ProfileUpdateRequest model)
        {
            var user = (User)this.HttpContext.Items["User"];

            if (string.IsNullOrEmpty(model.Email))
            {
                return BadRequest(new { message = "The field 'Username' can not be empty!" });
            }

            var CheckEmail = _db.User.FirstOrDefault(x => x.Email == model.Email && x.Id != user.Id);
            if (CheckEmail != null)
            {
                return BadRequest(new { message = "The email has already been taken.!" });
            }

            if (!string.IsNullOrEmpty(model.Phone))
            {
                var CheckPhone = _db.User.FirstOrDefault(x => x.Phone == model.Phone && x.Id != user.Id);
                if (CheckPhone != null)
                {
                    return BadRequest(new { message = "The phone number has already been taken.!" });
                }
            }

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Gender = model.Gender;
            user.Address = model.Address;
            user.AboutMe = model.AboutMe;

            if (!string.IsNullOrEmpty(model.Phone))
            {
                user.Phone = model.Phone;
            }
            _db.Update(user);
            _db.SaveChanges();

            return Ok(new { status = true, data = user, message = "ok" });
        }

        [HttpPost("password/update")]
        public IActionResult PasswordUpdate([FromBody] ChangePasswordRequest model)
        {
            var user = (User)this.HttpContext.Items["User"];

            if (string.IsNullOrEmpty(model.OldPassword))
            {
                return BadRequest(new { message = "The field 'OldPassword' can not be empty!" });
            }

            if (string.IsNullOrEmpty(model.NewPassword))
            {
                return BadRequest(new { message = "The field 'NewPassword' can not be empty!" });
            }

            if (string.IsNullOrEmpty(model.ConfirmNewPassword))
            {
                return BadRequest(new { message = "The field 'ConfirmNewPassword' can not be empty!" });
            }

            if (model.NewPassword.Length < 8)
            {
                return BadRequest(new { message = "The password must be at least 8 characters.!" });
            }

            if (model.NewPassword != model.ConfirmNewPassword)
            {
                return BadRequest(new { message = "The password confirmation does not match.!" });
            }

            if (!BCrypt.Net.BCrypt.Verify(model.OldPassword, user.Password))
            {
                return BadRequest(new { message = "Your password was not updated, since the provided current password does not match.!!" });
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            _db.Update(user);
            _db.SaveChanges();

            return Ok(new { status = true, data = user, message = "Your password has been changed!!" });
        }

    }
}
