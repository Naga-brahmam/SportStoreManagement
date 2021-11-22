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
    public class ItemManagementModulesController : ControllerBase
    {
        private readonly Sports_ShopContext _context;

        public ItemManagementModulesController(Sports_ShopContext context)
        {
            _context = context;
        }

        // GET: api/ItemManagementModules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemManagementModule>>> GetItemManagementModule()
        {
            return await _context.ItemManagementModule.ToListAsync();
        }

        // GET: api/ItemManagementModules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemManagementModule>> GetItemManagementModule(int id)
        {
            var itemManagementModule = await _context.ItemManagementModule.FindAsync(id);

            if (itemManagementModule == null)
            {
                return NotFound();
            }

            return itemManagementModule;
        }

        // PUT: api/ItemManagementModules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemManagementModule(int id, ItemManagementModule itemManagementModule)
        {
            if (id != itemManagementModule.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(itemManagementModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemManagementModuleExists(id))
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

        // POST: api/ItemManagementModules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemManagementModule>> PostItemManagementModule(ItemManagementModule itemManagementModule)
        {
            _context.ItemManagementModule.Add(itemManagementModule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemManagementModule", new { id = itemManagementModule.ItemId }, itemManagementModule);
        }

        // DELETE: api/ItemManagementModules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemManagementModule(int id)
        {
            var itemManagementModule = await _context.ItemManagementModule.FindAsync(id);
            if (itemManagementModule == null)
            {
                return NotFound();
            }

            _context.ItemManagementModule.Remove(itemManagementModule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemManagementModuleExists(int id)
        {
            return _context.ItemManagementModule.Any(e => e.ItemId == id);
        }
    }
}
