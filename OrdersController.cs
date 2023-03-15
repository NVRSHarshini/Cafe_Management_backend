using FoodOrdering.Models;
using FoodOrdering._context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrdering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DBContext _context;
        public OrdersController(DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders> >GetOrdersById(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            return orders;
        }
        //private readonly IOrdersRepo Repositories = null;
        //public OrdersController(IOrdersRepo repo)
        //{
        //    Repositories = repo;
        //}
        //[HttpGet]
        //public ActionResult<List<Orders>> Get()
        //{
        //    List<Orders> orders = FoodOrdering.Repositories.GetAllOrders();
        //    if (orders.Count > 0)
        //    {
        //        return orders;

        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        [HttpPost]
        public async Task<ActionResult<Orders>> Post(Orders orders)
        {

            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Post", new { id = orders.OrderId },orders);
        }
        //[HttpPost]
        //public string Post(Orders Orders)
        //{
        //    string Response = Repositories.AddnewOrder(Orders);
        //    return Response;
        //}
    }
}
