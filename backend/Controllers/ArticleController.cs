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

using backend.Models;
using backend.Models.Entities;
using backend.Models.Requests;
using backend.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            List<ArticleResult> newArticle = _db.Database.SqlQueryRaw<ArticleResult>("SELECT a.\"Id\", a.\"Title\", a.\"Slug\", a.\"Description\", a.\"CreatedAt\", u.\"FirstName\", u.\"LastName\", u.\"Gender\",( SELECT string_agg(r.\"Name\", ',') AS r FROM \"public\".\"Reference\" r WHERE r.\"Id\" IN ( SELECT \"ReferencesId\" FROM \"public\".\"ArticleReference\" WHERE \"ArticlesId\" = a.\"Id\")) Categories FROM \"public\".\"Article\" a INNER JOIN \"public\".\"User\" u ON u.\"Id\" = a.\"UserId\" WHERE a.\"Status\" = 1  ORDER BY  a.\"Id\" DESC LIMIT 1 OFFSET 0").ToList();
            List<ArticleResult> newArticles = _db.Database.SqlQueryRaw<ArticleResult>("SELECT a.\"Id\", a.\"Title\", a.\"Slug\", a.\"Description\", a.\"CreatedAt\", u.\"FirstName\", u.\"LastName\", u.\"Gender\",( SELECT string_agg(r.\"Name\", ',') AS r FROM \"public\".\"Reference\" r WHERE r.\"Id\" IN ( SELECT \"ReferencesId\" FROM \"public\".\"ArticleReference\" WHERE \"ArticlesId\" = a.\"Id\")) Categories FROM \"public\".\"Article\" a INNER JOIN \"public\".\"User\" u ON u.\"Id\" = a.\"UserId\" WHERE a.\"Status\" = 1  ORDER BY  a.\"Id\" DESC LIMIT 3 OFFSET 1").ToList();
            List<ArticleResult> stories = _db.Database.SqlQueryRaw<ArticleResult>("SELECT a.\"Id\", a.\"Title\", a.\"Slug\", a.\"Description\", a.\"CreatedAt\", u.\"FirstName\", u.\"LastName\", u.\"Gender\",( SELECT string_agg(r.\"Name\", ',') AS r FROM \"public\".\"Reference\" r WHERE r.\"Id\" IN ( SELECT \"ReferencesId\" FROM \"public\".\"ArticleReference\" WHERE \"ArticlesId\" = a.\"Id\")) Categories FROM \"public\".\"Article\" a INNER JOIN \"public\".\"User\" u ON u.\"Id\" = a.\"UserId\" WHERE a.\"Status\" = 1 ORDER BY  a.\"Id\" DESC LIMIT " + limit).ToList();

            IDictionary<string, object> response = new Dictionary<string, object>();
            bool continueArticle = limit <= _db.Article.Where(x => x.Status == 1).Count();

            response.Add("continue", continueArticle);
            response.Add("new_article", newArticle.Count > 0 ? newArticle[0] : null);
            response.Add("new_articles", newArticles);
            response.Add("page", Page);
            response.Add("stories", stories);

            return Ok(new { status = true, message = "ok", data = response });
        }

        [HttpGet("detail/{slug}")]
        public IActionResult Detail(String slug)
        {
            var model = _db.Article.Include(x => x.User).Include(x=> x.References).Where(x => x.Slug == slug)
                .Select(x => new { 
                    x.Id,
                    x.Title,
                    x.Description,
                    x.CreatedAt,
                    x.Content,
                    x.User.FirstName,
                    x.User.LastName,
                    x.User.Gender,
                    x.User.Email,
                    x.User.AboutMe,
                    x.References
                })
                .FirstOrDefault();

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
            List<ArticleComment> elements = _db.ArticleComment.Include(x => x.User).Where(x => x.ArticleId == id).OrderByDescending(x => x.Id).ToList();
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
