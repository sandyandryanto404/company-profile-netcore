using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace backend.Models.Entities
{
    [Index(nameof(Email))]
    [Index(nameof(Token))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class PasswordReset
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Token { get; set; }

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;
    }
}
