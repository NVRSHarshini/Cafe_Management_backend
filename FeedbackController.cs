using FoodOrdering.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly DBContext _context;
        public FeedbackController(DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedback()
        {
            return await _context.Feedback.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Feedback>> Post(Feedback feedback)
        {

            _context.Feedback.Add(feedback);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", new { id = feedback.Fid }, feedback);
        }
    }
}
