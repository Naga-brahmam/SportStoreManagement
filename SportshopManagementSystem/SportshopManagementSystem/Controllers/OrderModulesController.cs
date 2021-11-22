using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportshopManagementSystem.Models;

namespace SportshopManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class OrderModulesController : ControllerBase
    {
        private readonly Sports_ShopContext _context;

        public OrderModulesController(Sports_ShopContext context)
        {
            _context = context;
        }

        // GET: api/OrderModules
        [HttpGet]
        public IQueryable<Object> GetOrderModule()
        {
            return (from p in _context.OrderModule
                    join e in _context.ItemManagementModule
                    on p.ItemId equals e.ItemId
                    join t in _context.CustomerManagementModule
                    on p.CustomerId equals t.CustomerId
                    select new
                    {
                        CustomeName = t.Name,
                        itemName=e.Name,
                        price=e.Price,
                        orderdate=p.OrderDate,
                        delivarydate=p.DelivaryDate,
                        paymentmode=p.PaymentMode

                    });
        }

        // GET: api/OrderModules/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ItemManagementModule>> GetOrderModule(int id)
        {
            var k = new List<ItemManagementModule>();
            ItemManagementModule m = null;
            var orderModule= _context.OrderModule.Where(p=>p.CustomerId==id).Join(_context.ItemManagementModule, e => e.Item.ItemId, ep => ep.ItemId ,(e, ep) => new
            {

                Name = ep.Name,
                Price = ep.Price
            }).ToList();
            foreach (var i in orderModule)
            {
                m = new ItemManagementModule();
                m.Name = i.Name;
                m.Price = i.Price;
                k.Add(m);
            }
            return k;
        }

        // PUT: api/OrderModules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderModule(int id, OrderModule orderModule)
        {
            if (id != orderModule.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderModuleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrderModules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderModule>> PostOrderModule(OrderModule orderModule)
        {
            _context.OrderModule.Add(orderModule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderModule", new { id = orderModule.OrderId }, orderModule);
        }

        // DELETE: api/OrderModules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderModule(int id)
        {
            var orderModule = await _context.OrderModule.FindAsync(id);
            if (orderModule == null)
            {
                return NotFound();
            }

            _context.OrderModule.Remove(orderModule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderModuleExists(int id)
        {
            return _context.OrderModule.Any(e => e.OrderId == id);
        }
    }
}
