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

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend.Models.Entities
{
    [Index(nameof(Email))]
    [Index(nameof(Phone))]
    [Index(nameof(Password))]
    [Index(nameof(Status))]
    [Index(nameof(ResetToken))]
    [Index(nameof(ConfirmToken))]
    [Index(nameof(Image))]
    [Index(nameof(FirstName))]
    [Index(nameof(LastName))]
    [Index(nameof(Gender))]
    [Index(nameof(Country))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string Email { get; set; }


        [Column(TypeName = "varchar(64)")]
        public string Phone { get; set; } = null;

        [Column(TypeName = "varchar(255)")]
        [JsonIgnore]
        public string Password { get; set; }

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

        [Column(TypeName = "text")]
        public string? Address { get; set; } = null;

        [Column(TypeName = "text")]
        public string? AboutMe { get; set; } = null;

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        [Column(TypeName = "varchar(191)")]
        public string? ResetToken { get; set; } = null;

        [Required]
        [Column(TypeName = "varchar(191)")]
        public string ConfirmToken { get; set; }

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.UtcNow;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Article> Article { get; set; }
        public virtual ICollection<ArticleComment> ArticleComment { get; set; }

    }
}
