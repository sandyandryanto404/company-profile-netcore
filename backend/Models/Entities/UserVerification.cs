using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace backend.Models.Entities
{
    [Index(nameof(UserId))]
    [Index(nameof(Email))]
    [Index(nameof(Token))]
    [Index(nameof(Status))]
    [Index(nameof(ExpiredAt))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class UserVerification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Token { get; set; }

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public DateTime ExpiredAt { get; set; }

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;
    }
}
