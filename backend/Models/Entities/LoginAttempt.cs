using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Entities
{
    [Index(nameof(IpAddress))]
    [Index(nameof(Login))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class LoginAttempt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string IpAddress { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Login { get; set; }

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;
    }

}
