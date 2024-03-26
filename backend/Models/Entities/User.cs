using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Models.Entities
{
    [Index(nameof(Image))]
    [Index(nameof(FirstName))]
    [Index(nameof(LastName))]
    [Index(nameof(Gender))]
    [Index(nameof(Country))]
    [Index(nameof(Province))]
    [Index(nameof(Regency))]
    [Index(nameof(BirthDate))]
    [Index(nameof(BirthPlace))]
    [Index(nameof(PostalCode))]
    [Index(nameof(Twitter))]
    [Index(nameof(Facebook))]
    [Index(nameof(Instagram))]
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    [Index(nameof(Password))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Image { get; set; } = null;

        [Column(TypeName = "varchar(191)")]
        public string? FirstName { get; set; } = null;

        [Column(TypeName = "varchar(191)")]
        public string? LastName { get; set; } = null;

        [Column(TypeName = "varchar(2)")]
        public string? Gender { get; set; } = null;

        [Column(TypeName = "varchar(191)")]
        public string? Country { get; set; } = null;

        [Column(TypeName = "varchar(191)")]
        public string? Province { get; set; } = null;

        [Column(TypeName = "varchar(191)")]
        public string? Regency { get; set; } = null;

        [Column(TypeName = "varchar(20)")]
        public string? PostalCode { get; set; } = null;

        [Column(TypeName = "varchar(191)")]
        public string? BirthPlace { get; set; } = null;

        public Nullable<System.DateTime> BirthDate { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string? Twitter { get; set; } = null;

        [Column(TypeName = "varchar(191)")]
        public string? Facebook { get; set; } = null;

        [Column(TypeName = "varchar(191)")]
        public string? Instagram { get; set; } = null;

        [Column(TypeName = "text")]
        public string? Address { get; set; } = null;

        [Column(TypeName = "text")]
        public string? AboutMe { get; set; } = null;

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Email { get; set; }


        [Column(TypeName = "varchar(64)")]
        public string Phone { get; set; } = null;

        [Column(TypeName = "varchar(255)")]
        [JsonIgnore]
        public string Password { get; set; }

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;
        public virtual ICollection<UserNotification> UserNotification { get; set; }
        public virtual ICollection<UserVerification> UserVerification { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
