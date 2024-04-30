using backend.Models;
using backend.Models.Entities;
using backend.Models.Requests;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly AppDbContext _db;

        public ArticleController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public IActionResult List(int Page = 1)
        {
            int limit = 3 * Page;
            Article newArticle = _db.Article.Where(x=> x.Status == 1).OrderByDescending(x=> x.Id).FirstOrDefault();
            List<Article> newArticles = _db.Article.Where(x => x.Status == 1 && x.Id != newArticle.Id).Take(3).OrderByDescending(x => x.Id).ToList();
            List<Article> stories = _db.Article.Where(x => x.Status == 1).Take(limit).OrderByDescending(x => x.Id).ToList();

            IDictionary<string, object> response = new Dictionary<string, object>();
            bool continueArticle = limit <= _db.Article.Where(x => x.Status == 1).Count();

            response.Add("continue", continueArticle);
            response.Add("new_article", newArticle);
            response.Add("new_articles", newArticles);
            response.Add("page", Page);
            response.Add("stories", stories);

            return Ok(new { status = true, message = "ok", data = response });
        }

        [HttpGet("detail/{slug}")]
        public IActionResult Detail(String slug)
        {
            var model = _db.Article.FirstOrDefault(x => x.Slug == slug);

            if (model == null)
            {
                return BadRequest(new { message = "Record with id : " + slug + " not found !" });
            }

            return Ok(new { status = true, data = model, message = "ok" });
        }

        [HttpGet("comments/{id}")]
        public IActionResult ListComment(long id)
        {
            IDictionary<string, object> response = new Dictionary<string, object>();
            List<ArticleComment> elements = _db.ArticleComment.Where(x => x.ArticleId == id).OrderByDescending(x => x.Id).ToList();
            List<ArticleComment> comments = this.generateCommentTree(elements);
            response.Add("comments", comments);
            return Ok(new { status = true, message = "ok", data = response });
        }

        [HttpPost("comments/{id}")]
        [Authorize]
        public IActionResult Message(long id, [FromBody] CommentRequest model)
        {
            var user = (User)this.HttpContext.Items["User"];
            ArticleComment comment = new ArticleComment();

            comment.User = user;
            comment.ArticleId = id;
            comment.Content = model.Comment;
            comment.Status = 1;
            _db.Add(comment);
            _db.SaveChanges();
            return Ok(new { status = true, data = comment, message = "ok" });
        }

        private List<ArticleComment> generateCommentTree(List<ArticleComment> comments, Nullable<long> ParentId = null)
        {
            List<ArticleComment> branch = new List<ArticleComment>();

            foreach(var element in comments)
            {

                if (element.ParentId == ParentId)
                {
                    List<ArticleComment> children = this.generateCommentTree(comments, element.Id);
                    if (children.Count > 0)
                    {
                        element.Children = children;
                    }
                    else
                    {
                        element.Children = new List<ArticleComment>();
                    }
                    branch.Add(element);
                }


            }

            return branch;
        }


    }
}
