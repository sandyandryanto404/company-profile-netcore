using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace backend.Models.Entities
{
    [Index(nameof(UserId))]
    [Index(nameof(Subject))]
    [Index(nameof(Description))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class UserNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string? Subject { get; set; } = null;

        [Column(TypeName = "varchar(255)")]
        public string? Description { get; set; } = null;

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;
    }
}
