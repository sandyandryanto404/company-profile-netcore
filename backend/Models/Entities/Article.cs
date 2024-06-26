﻿/**
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
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Entities
{
    [Index(nameof(Title))]
    [Index(nameof(UserId))]
    [Index(nameof(Slug))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class Article
    {
        public Article()
        {
            this.References = new HashSet<Reference>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

#nullable enable
        [Column(TypeName = "varchar(255)")]
        public string? Image { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Slug { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.UtcNow;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Reference> References { get; set; }
        public virtual ICollection<ArticleComment> ArticleComment { get; set; }
    }
}
