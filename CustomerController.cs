using FoodOrdering.Models;
using FoodOrdering._context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly DBContext _context;
        public CustomerController(DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomersById(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return customers;
        }
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers customers)
        {

            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();
            return CreatedAtAction("PostCustomers", new { id = customers.ID }, customers);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, Customers customers)
        {
            if (id != customers.ID)
            {
                return BadRequest();
            }
            _context.Entry(customers).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (customers.ID == 0)
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomer(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return customers;
        }
        [HttpGet]
        [Route("{email},{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            //var user = await context.Users.FindAsync(id);
            var user = await _context.Customers.Where(m => m.Email == email).ToListAsync();
            var pw = await _context.Customers.Where(m => m.Password == password).ToListAsync();
            if (user.Count() != 0 && pw.Count() != 0)
            {
                return Ok(user[0]);
            }
            return NotFound("User is invalid");
        }
    }
}

