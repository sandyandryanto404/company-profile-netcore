using backend.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Requests
{
    public class SubscribeRequest
    {
        public string Email { get; set; }
    }

    public class ContactRequest()
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class CommentRequest()
    {
        public string Comment { get; set; }
    }

    public class ListArticleRequest()
    {
        public int Page { get; set; } = 1;
    }

    public class CommentTree()
    {
        public long Id { get; set; }
        public Nullable<long> ParentId { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public List<CommentTree> Childeren { get; set; } = new List<CommentTree>();
    }

    public class ReponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsResponse { get; set; }
    }

    public class SingleFileModel : ReponseModel
    {
        [Required(ErrorMessage = "Please enter file name")]
        public string FileName { get; set; }
        [Required(ErrorMessage = "Please select file")]
        public IFormFile File { get; set; }
    }

    public class ArticleResult
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public Nullable<System.DateTime> CreatedAt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Categories { get; set; }
    }

}
