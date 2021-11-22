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
    public class CustomerManagementModulesController : ControllerBase
    {
        private readonly Sports_ShopContext _context;

        public CustomerManagementModulesController(Sports_ShopContext context)
        {
            _context = context;
        }

        // GET: api/CustomerManagementModules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerManagementModule>>> GetCustomerManagementModule()
        {
            return await _context.CustomerManagementModule.ToListAsync();
        }

        // GET: api/CustomerManagementModules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerManagementModule>> GetCustomerManagementModule(int id)
        {
            var customerManagementModule = await _context.CustomerManagementModule.FindAsync(id);

            if (customerManagementModule == null)
            {
                return NotFound();
            }

            return customerManagementModule;
        }

        // PUT: api/CustomerManagementModules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerManagementModule(int id, CustomerManagementModule customerManagementModule)
        {
            if (id != customerManagementModule.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerManagementModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerManagementModuleExists(id))
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

        // POST: api/CustomerManagementModules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerManagementModule>> PostCustomerManagementModule(CustomerManagementModule customerManagementModule)
        {
            _context.CustomerManagementModule.Add(customerManagementModule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerManagementModule", new { id = customerManagementModule.CustomerId }, customerManagementModule);
        }

        // DELETE: api/CustomerManagementModules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerManagementModule(int id)
        {
            var customerManagementModule = await _context.CustomerManagementModule.FindAsync(id);
            if (customerManagementModule == null)
            {
                return NotFound();
            }

            _context.CustomerManagementModule.Remove(customerManagementModule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerManagementModuleExists(int id)
        {
            return _context.CustomerManagementModule.Any(e => e.CustomerId == id);
        }
    }
}
