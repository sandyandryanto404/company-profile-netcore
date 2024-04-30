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

}
