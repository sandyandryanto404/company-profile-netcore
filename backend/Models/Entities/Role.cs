using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Faker;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string? Description { get; set; } = null;

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<User> Users { get; set; }
    }
}
