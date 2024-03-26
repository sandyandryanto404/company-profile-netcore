

using backend.Models.Entities;

namespace backend.Models.Responses
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Token { get; set; }

        public int Status { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Phone = user.Phone;
            Token = token;
            Status = user.Status;
        }
    }
}
