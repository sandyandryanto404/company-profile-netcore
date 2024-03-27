using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace backend.Models.Entities
{
    [Index(nameof(ParentId))]
    [Index(nameof(UserId))]
    [Index(nameof(ArticleId))]
    [Index(nameof(Status))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(UpdatedAt))]
    public class ArticleComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DisplayName("Parent")]
        public long ParentId { get; set; }
        public virtual ArticleComment Parent { get; set; }

        [DisplayName("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [DisplayName("Article")]
        public long ArticleId { get; set; }
        public virtual Article Article { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Column(TypeName = "int2")]
        public int Status { get; set; } = 0;

        public Nullable<System.DateTime> CreatedAt { get; set; } = DateTime.Now;
        public Nullable<System.DateTime> UpdatedAt { get; set; } = DateTime.Now;
    }
}
