using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


namespace backend.Models.Entities
{
    [Index(nameof(CustomerId))]
    [Index(nameof(Image))]
    [Index(nameof(Name))]
    [Index(nameof(Position))]
    [Index(nameof(Sort))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Testimonial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("Customer")]
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string? Image { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string Position { get; set; }

        [Column(TypeName = "text")]
        public string Quote { get; set; }

        [Column(TypeName = "int4")]
        public int Sort { get; set; } = 0;

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;
    }
}
