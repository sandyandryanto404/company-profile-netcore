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
