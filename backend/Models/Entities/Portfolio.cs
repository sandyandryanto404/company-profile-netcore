using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Entities
{
    [Index(nameof(CustomerId))]
    [Index(nameof(ReferenceId))]
    [Index(nameof(Title))]
    [Index(nameof(ProjectDate))]
    [Index(nameof(ProjectUrl))]
    [Index(nameof(Sort))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("Customer")]
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [DisplayName("Reference")]
        public long ReferenceId { get; set; }
        public virtual Reference Reference { get; set; }

        [Column(TypeName = "varchar(191)")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public Nullable<System.DateTime> ProjectDate { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? ProjectUrl { get; set; }

        [Column(TypeName = "int4")]
        public int Sort { get; set; } = 0;

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<PortfolioImage> PortfolioImage { get; set; }

    }
}
