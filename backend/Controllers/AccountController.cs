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
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db)
        {
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
                return BadRequest(new { message = "The field 'Email' can not be empty!" });
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
            user.Country = model.Country;
            user.Gender = model.Gender;
            user.Address = model.Address;
            user.AboutMe = model.AboutMe;

            if (!string.IsNullOrEmpty(model.Phone))
            {
                user.Phone = model.Phone;
            }
            _db.Update(user);
            _db.SaveChanges();

            return Ok(new { status = true, data = user, message = "Yor profile has been changed !!" });
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

        [HttpPost("profile/upload")]
        public IActionResult upload(IFormCollection form)
        {
            var user = (User)this.HttpContext.Items["User"];

            if (HttpContext.Request.Form.Files.Count == 0)
            {
                return BadRequest(new { message = "Please select file !" });
            }

            SingleFileModel model = new SingleFileModel();
            model.File = HttpContext.Request.Form.Files.FirstOrDefault();

            if (ModelState.IsValid)
            {
                model.IsResponse = true;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(model.File.FileName);
                string fileName = Guid.NewGuid().ToString() + "" + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }

                if (!String.IsNullOrWhiteSpace(user.Image))
                {
                    string fileNameWithPathUser = Path.Combine(path, user.Image);
                    if(System.IO.File.Exists(fileNameWithPathUser))
                    {
                        System.IO.File.Delete(fileNameWithPathUser);
                    }
                }

                user.Image = fileName;
                _db.Update(user);
                _db.SaveChanges();

                model.FileName = "Uploads/" + fileName;
                model.IsSuccess = true;
                model.Message = "File upload successfully";
            }

            return Ok(model);
        }
    }
}
