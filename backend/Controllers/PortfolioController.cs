using backend.Models;
using backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _db;

        public PortfolioController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            List<Portfolio> portfolios = _db.Portfolio.Where(x => x.Status == 1).OrderBy(x => x.Sort).ToList();
            return Ok(new { status = true, data = portfolios });
        }

        [HttpGet("{id}")]
        public IActionResult Detail(long id)
        {
            var model = _db.Portfolio.FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                return BadRequest(new { message = "Record with id : " + id + " not found !" });
            }

            return Ok(new { status = true, data = model, message = "" });
        }
    }
}
