using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Faker;
using backend.Models.Entities;
using Microsoft.AspNetCore.Identity.Data;
using backend.Models.Requests;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PageController : Controller
    {
        private readonly AppDbContext _db;

        public PageController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new { status = true });
        }

        [HttpGet("home")]
        public IActionResult Home()
        {
            IDictionary<string, object> response = new Dictionary<string, object>();

            IDictionary<string, string> header = new Dictionary<string, string>();
            header.Add("title", Faker.Lorem.Sentence(5));
            header.Add("description", Faker.Lorem.Sentence(20));
            response.Add("header", header);

            Testimonial testimonial = _db.Testimonial.Include(x=> x.Customer).Where(x => x.Status == 1).Take(4).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            List<Slider> sliders = _db.Slider.Where(x => x.Status == 1).OrderBy(x => x.Sort).ToList();
            List<Service> services = _db.Service.Where(x => x.Status == 1).Take(4).OrderBy(x => Guid.NewGuid()).ToList();
            List<Article> articles = _db.Article.Where(x => x.Status == 1).OrderBy(x => Guid.NewGuid()).ToList();

            List<ArticleResult> articleResults = _db.Database.SqlQueryRaw<ArticleResult>("SELECT a.\"Id\", a.\"Title\", a.\"Slug\", a.\"Description\", a.\"CreatedAt\", u.\"FirstName\", u.\"LastName\", u.\"Gender\",( SELECT string_agg(r.\"Name\", ',') AS r FROM \"public\".\"Reference\" r WHERE r.\"Id\" IN ( SELECT \"ReferencesId\" FROM \"public\".\"ArticleReference\" WHERE \"ArticlesId\" = a.\"Id\")) Categories FROM \"public\".\"Article\" a INNER JOIN \"public\".\"User\" u ON u.\"Id\" = a.\"UserId\" ORDER BY random() LIMIT 3").ToList();


            response.Add("testimonial", testimonial);
            response.Add("sliders", sliders);
            response.Add("services", services);
            response.Add("articles", articleResults);

            return Ok(new { status = true, message = "ok", data = response });
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            IDictionary<string, object> response = new Dictionary<string, object>();

            IDictionary<string, string> header = new Dictionary<string, string>();
            header.Add("title", Faker.Lorem.Sentence(5));
            header.Add("description", Faker.Lorem.Sentence(20));
            response.Add("header", header);

            IDictionary<string, string> section1 = new Dictionary<string, string>();
            section1.Add("title", Faker.Lorem.Sentence(5));
            section1.Add("description", Faker.Lorem.Paragraph());
            response.Add("section1", section1);

            IDictionary<string, string> section2 = new Dictionary<string, string>();
            section2.Add("title", Faker.Lorem.Sentence(5));
            section2.Add("description", Faker.Lorem.Paragraph());
            response.Add("section2", section2);

            List<Team> teams = _db.Team.Where(x => x.Status == 1).OrderBy(x => x.Sort).ToList();
            response.Add("teams", teams);

            return Ok(new { status = true, message = "ok", data = response });
        }

        [HttpGet("service")]
        public IActionResult Service()
        {
            IDictionary<string, object> response = new Dictionary<string, object>();

            IDictionary<string, string> header = new Dictionary<string, string>();
            header.Add("title", Faker.Lorem.Sentence(5));
            header.Add("description", Faker.Lorem.Sentence(20));
            response.Add("header", header);

            List<Service> services = _db.Service.Where(x => x.Status == 1).OrderBy(x => Guid.NewGuid()).ToList();
            List<Customer> customers = _db.Customer.Where(x => x.Status == 1).OrderBy(x => Guid.NewGuid()).ToList();
            List<Testimonial> testimonials = _db.Testimonial.Where(x => x.Status == 1).OrderBy(x => Guid.NewGuid()).ToList();

            response.Add("services", services);
            response.Add("customers", customers);
            response.Add("testimonials", testimonials);

            return Ok(new { status = true, message = "ok", data = response });
        }

        [HttpGet("faq")]
        public IActionResult Faq()
        {
            IDictionary<string, object> response = new Dictionary<string, object>();
            List<Faq> faqs1 = _db.Faq.Where(x => x.Status == 1 && x.Sort <= 5).OrderBy(x => Guid.NewGuid()).ToList();
            List<Faq> faqs2 = _db.Faq.Where(x => x.Status == 1 && x.Sort > 5).OrderBy(x => Guid.NewGuid()).ToList();

            response.Add("faqs1", faqs1);
            response.Add("faqs2", faqs2);

            return Ok(new { status = true, message = "ok", data = response });
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            IDictionary<string, object> response = new Dictionary<string, object>();
            List<Service> services = _db.Service.Where(x => x.Status == 1).Take(4).OrderBy(x => Guid.NewGuid()).ToList();
            response.Add("services", services);
            return Ok(new { status = true, message = "ok", data = response });
        }

        [HttpPost("message")]
        public IActionResult Message([FromBody] ContactRequest model)
        {
            Contact c = new Contact();
            c.Name = model.Name;
            c.Subject = model.Subject;
            c.Email = model.Email;
            c.Message = model.Message;
            c.Status = 0;
            _db.Add(c);
            _db.SaveChanges();
            return Ok(new { status = true });
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] SubscribeRequest model)
        {
            return Ok(new { status = true, email = model.Email });
        }

       

    }
}
