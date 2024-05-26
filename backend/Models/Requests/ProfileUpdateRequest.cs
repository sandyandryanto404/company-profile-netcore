namespace backend.Models.Requests
{
    public class ProfileUpdateRequest
    {
        public string Email { get; set; }
        public string Phone { get; set; } = null;
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Gender { get; set; } = null;
        public string? Country { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? AboutMe { get; set; } = null;
    }
}
