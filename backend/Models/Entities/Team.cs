using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Entities
{
    [Index(nameof(Image))]
    [Index(nameof(Name))]
    [Index(nameof(Email))]
    [Index(nameof(Phone))]
    [Index(nameof(PositionName))]
    [Index(nameof(Twitter))]
    [Index(nameof(Facebook))]
    [Index(nameof(Instagram))]
    [Index(nameof(LinkedIn))]
    [Index(nameof(Sort))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string? Image { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string PositionName { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Twitter { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Facebook { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Instagram { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? LinkedIn { get; set; }

        [Column(TypeName = "text")]
        public string Address { get; set; }

        [Column(TypeName = "int4")]
        public int Sort { get; set; } = 0;

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;
    }
}
