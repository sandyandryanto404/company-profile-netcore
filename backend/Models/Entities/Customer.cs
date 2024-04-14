/**
 * This file is part of the Sandy Andryanto Company Profile Website.
 *
 * @author     Sandy Andryanto <sandy.andryanto404@gmail.com>
 * @copyright  2024
 *
 * For the full copyright and license information,
 * please view the LICENSE.md file that was distributed
 * with this source code.
 */

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Entities
{
    [Index(nameof(Image))]
    [Index(nameof(Name))]
    [Index(nameof(Email))]
    [Index(nameof(Phone))]
    [Index(nameof(Address))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Customer
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

        [Column(TypeName = "text")]
        public string Address { get; set; }

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.UtcNow;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Portfolio> Portfolio { get; set; }

        public virtual ICollection<Testimonial> Testimonial { get; set; }

    }
}
