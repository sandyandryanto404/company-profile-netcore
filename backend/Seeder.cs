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
using Faker;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using Slugify;

namespace backend
{
    public class Seeder
    {
        private readonly AppDbContext db;

        public Seeder(AppDbContext _db)
        {
            this.db = _db;
        }

        public void run()
        {
            this.CreateUser();
            this.CreateReference();
            this.CreateContact();
            this.CreateCustomer();
            this.CreateFaq();
            this.CreateService();
            this.CreateSlider();
            this.CreateTeam();
            this.CreateTestimonial();
            this.CreatePortofolio();
            this.CreateArticle();
        }

        private void CreateUser()
        {
            int TotalRows = this.db.User.Count();
            List<String> Genders = new List<string> {"M", "F"};
            if (TotalRows == 0)
            {
                for(int i = 1; i <= 10; i++)
                {
                    string Gender = Genders.OrderBy(s => Guid.NewGuid()).First();
                    User user = new User();
                    user.Email = Faker.Internet.Email();
                    user.Phone = Faker.Phone.Number().ToString();
                    user.Password = BCrypt.Net.BCrypt.HashPassword("p4ssw0rd!");
                    user.ConfirmToken = Guid.NewGuid().ToString();
                    user.Status = 1;
                    user.FirstName = Faker.Name.First();
                    user.LastName = Faker.Name.Last();
                    user.Gender = Gender;
                    user.Country = Faker.Address.Country();
                    user.Address = Faker.Address.StreetAddress();
                    user.AboutMe = Faker.Lorem.Paragraph();
                    this.db.User.Add(user);
                }
                this.db.SaveChanges();
            }
        }

        private void CreateReference()
        {
            int TotalRows = this.db.Reference.Count();
            if (TotalRows == 0)
            {
                List<String> Articles = new List<string> {
                    "Health and wellness",
                    "Technology and gadgets",
                    "Business and finance",
                    "Travel and tourism",
                    "Lifestyle and fashion"
                };

                List<String> Tags = new List<string> {
                    "Mental Health",
                    "Fitness and Exercise",
                    "Alternative Medicine",
                    "Artificial Intelligence",
                    "Network Security",
                    "Cloud Computing",
                    "Entrepreneurship",
                    "Personal Finance",
                    "Marketing and Branding",
                    "Travel Tips and Tricks",
                    "Cultural Experiences",
                    "Destination Guides",
                    "Beauty and Fashion Trends",
                    "Celebrity News and Gossip",
                    "Parenting and Family Life",
                };

                List<String> Portfolios = new List<string> {
                    "3D Modeling",
                    "Web Application",
                    "Mobile Application",
                    "Illustrator Design",
                    "UX Design"
                };

                foreach(var a in Articles)
                {
                    Reference ra = new Reference();
                    ra.Slug = new SlugHelper().GenerateSlug(a);
                    ra.Name = a;
                    ra.Description = Faker.Lorem.Paragraph(3);
                    ra.Status = 1;
                    ra.Type = 1;
                    this.db.Reference.Add(ra);
                }

                foreach(var t in Tags)
                {
                    Reference ta = new Reference();
                    ta.Slug = new SlugHelper().GenerateSlug(t);
                    ta.Name = t;
                    ta.Description = Faker.Lorem.Paragraph(3);
                    ta.Status = 1;
                    ta.Type = 2;
                    this.db.Reference.Add(ta);
                }

                foreach(var p in Portfolios)
                {
                    Reference pp = new Reference();
                    pp.Slug = new SlugHelper().GenerateSlug(p);
                    pp.Name = p;
                    pp.Description = Faker.Lorem.Paragraph(3);
                    pp.Status = 1;
                    pp.Type = 3;
                    this.db.Reference.Add(pp);
                }

                this.db.SaveChanges();
            }
        }

        private void CreateContact()
        {
            int TotalRows = this.db.Contact.Count();
            if (TotalRows == 0)
            {
                for(int i = 1; i<= 10; i++)
                {
                    Contact contact = new Contact();
                    contact.Name = Faker.Name.FullName();
                    contact.Email = Faker.Internet.FreeEmail();
                    contact.Subject = Faker.Lorem.Sentence(2);
                    contact.Message = Faker.Lorem.Paragraph(5);
                    contact.Status = 0;
                    this.db.Add(contact);
                }
                this.db.SaveChanges();
            }
        }

        private void CreateCustomer()
        {
            int TotalRows = this.db.Customer.Count();
            if (TotalRows == 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Customer customer = new Customer();
                    customer.Image = "customer" + i + ".jpg";
                    customer.Name = Faker.Company.Name();
                    customer.Email = Faker.Internet.FreeEmail();
                    customer.Phone = Faker.Phone.Number().ToString();
                    customer.Address = Faker.Address.StreetAddress();
                    customer.Status = 1;
                    this.db.Add(customer);
                }
                this.db.SaveChanges();
            }
        }

        private void CreateFaq()
        {
            int TotalRows = this.db.Faq.Count();
            if (TotalRows == 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Faq faq = new Faq();
                    faq.Question = Faker.Lorem.Sentence(5);
                    faq.Answer = Faker.Lorem.Paragraph(5);
                    faq.Status = 1;
                    faq.Sort = i;
                    this.db.Add(faq);
                }
                this.db.SaveChanges();
            }
        }

        private void CreateService()
        {
            int TotalRows = this.db.Service.Count();
            if (TotalRows == 0)
            {
                List<string> icons = new List<string> {
                    "bi bi-bicycle",
                    "bi bi-bookmarks",
                    "bi bi-box",
                    "bi bi-building-add",
                    "bi bi-calendar2-check",
                    "bi bi-cart4",
                    "bi bi-clipboard-data",
                    "bi bi-gift",
                    "bi bi-person-bounding-box",
                };

                foreach (var item in icons.Select((value, i) => new { i, value }))
                {
                    Service service = new Service();
                    service.Icon = item.value;
                    service.Title = Faker.Lorem.Sentence(2);
                    service.Description = Faker.Lorem.Paragraph(5);
                    service.Status = 1;
                    service.Sort = item.i;
                    this.db.Add(service);
                }
                this.db.SaveChanges();
            }   
        }

        private void CreateSlider()
        {
            int TotalRows = this.db.Slider.Count();
            if (TotalRows == 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Slider slider = new Slider();
                    slider.Image = "slider" + i + ".jpg";
                    slider.Title = Faker.Lorem.Sentence(5);
                    slider.Description = Faker.Lorem.Paragraph(5);
                    slider.Status = 1;
                    slider.Sort = i;
                    this.db.Add(slider);
                }
                this.db.SaveChanges();
            }
        }

        private void CreateTeam()
        {
            int TotalRows = this.db.Team.Count();
            if (TotalRows == 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Team team = new Team();
                    team.Image = "team" + i + ".jpg";
                    team.Name = Faker.Name.FullName();
                    team.Email = Faker.Internet.FreeEmail();
                    team.Phone = Faker.Phone.Number().ToString();
                    team.PositionName = this.getPosition();
                    team.Address = Faker.Address.StreetAddress();
                    team.Facebook = Faker.Internet.UserName();
                    team.Instagram = Faker.Internet.UserName();
                    team.Twitter = Faker.Internet.UserName();
                    team.LinkedIn = Faker.Internet.UserName();
                    team.Status = 1;
                    team.Sort = i;
                    this.db.Add(team);
                }
                this.db.SaveChanges();
            }
        }

        private void CreateTestimonial()
        {
            int TotalRows = this.db.Testimonial.Count();
            if (TotalRows == 0)
            {
                List<Customer> customers = this.db.Customer.ToList();
                foreach (var row in customers.Select((value, i) => new { i, value }))
                {
                    int sort = row.i + 1;
                    Testimonial testimonial = new Testimonial();
                    testimonial.Customer = row.value;
                    testimonial.Image = "testimonial" + sort + ".jpg";
                    testimonial.Name = Faker.Name.FullName();
                    testimonial.Position = this.getPosition();
                    testimonial.Quote = Faker.Lorem.Paragraph(2);
                    testimonial.Status = 1;
                    testimonial.Sort = sort;
                    this.db.Add(testimonial);
                }
                this.db.SaveChanges();
            }
        }

        private void CreatePortofolio()
        {
            int TotalRows = this.db.Portfolio.Count();
            if (TotalRows == 0)
            {
                for(int i = 1; i <= 9; i++)
                {
                    Reference category = this.db.Reference.Where(x=> x.Type == 3).OrderBy(x => Guid.NewGuid()).First();
                    Customer customer = this.db.Customer.OrderBy(x => Guid.NewGuid()).First();
                    Portfolio pp = new Portfolio();
                    pp.Customer = customer;
                    pp.Reference = category;
                    pp.Title = Faker.Lorem.Sentence(5);
                    pp.Description = Faker.Lorem.Paragraph(5);
                    pp.ProjectDate = Faker.Identification.DateOfBirth();
                    pp.ProjectUrl = Faker.Internet.SecureUrl();
                    pp.Status = 1;
                    pp.Sort = i;
                    this.db.Add(pp);

                    for(int j = 1; j <=4; j++)
                    {
                        PortfolioImage image = new PortfolioImage();
                        image.Portfolio = pp;
                        image.Image = "portfolio" + j + ".jpg";
                        image.Status = i == 1 ? 1 : 0;
                        this.db.Add(image);
                    }


                }

                this.db.SaveChanges();
            }
        }

        private void CreateArticle()
        {
            int TotalRows = this.db.Article.Count();
            if (TotalRows == 0)
            {
                List<User> users = this.db.User.ToList();
                foreach (var row in users.Select((value, i) => new { i, value }))
                {
                    int number = row.i + 1;
                    String title = Faker.Lorem.Sentence(5);
                    String slug = new SlugHelper().GenerateSlug(title);

                    List<Reference> categories = this.db.Reference.Where(x=> x.Type == 1).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
                    List<Reference> tags = this.db.Reference.Where(x => x.Type == 2).OrderBy(x => Guid.NewGuid()).Take(5).ToList();
                    List<Reference> references = categories.Concat(tags).ToList();

                    Article article = new Article();
                    article.Image = "article" + number + ".jpg";
                    article.References = references;
                    article.User = row.value;
                    article.Title = title;
                    article.Slug = slug;
                    article.Description = Faker.Lorem.Paragraph(1);
                    article.Content = Faker.Lorem.Paragraph(10);
                    article.Status = 1;
                    this.db.Add(article);

                    List<User> comments = this.db.User.Where(x=> x.Id != row.value.Id).OrderBy(x => Guid.NewGuid()).Take(2).ToList();
                    foreach(var cc in comments)
                    {
                        ArticleComment ac = new ArticleComment();
                        ac.Article = article;
                        ac.User = cc;
                        ac.Content = Faker.Lorem.Paragraph(2);
                        ac.Status = 1;
                        this.db.Add(ac);
                    }

                }
                this.db.SaveChanges();
            }
        }

       

        private string getPosition()
        {
            List<String> lists = new List<string>();
            System.Globalization.TextInfo ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;

            var jsonString = File.ReadAllText(@"./job_title.json");
            var jtoken = JToken.Parse(jsonString);
            foreach(var row in jtoken)
            {
                lists.Add(row.ToString());
            }

            var result = lists.OrderBy(s => Guid.NewGuid()).First();
            return ti.ToTitleCase(result);
        }

    }
}
