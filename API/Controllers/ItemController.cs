using ArcTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ArcTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> getItems()
        {
            List<Item> res = await _context.Items
                .OrderBy(x => x.Id)
                .ToListAsync();

            if (res.Count <= 0)
                return NotFound("No items found.");

            return res;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> getItem(ulong id)
        {
            Item? res = await _context.Items
                .FirstOrDefaultAsync(x =>
                    x.Id == id
                );

            if (res == null)
                return NotFound($"Item by id \"{id}\" was found.");

            return res;
        }

        [HttpGet("rarities")]
        public async Task<ActionResult<List<ItemRarity>>> getItemRarities()
        {
            List<ItemRarity> res = await _context.ItemRarities
                .ToListAsync();

            if (res == null)
                return NotFound("No ItemRarities found.");

            return res;
        }

        [HttpGet("rarities/{id}")]
        public async Task<ActionResult<ItemRarity>> getItemRarity(ulong id)
        {
            ItemRarity? res = await _context.ItemRarities
                .FirstOrDefaultAsync(x => 
                    x.Id == id
                );

            if (res == null)
                return NotFound($"ItemRarity by id \"{id}\" was found.");

            return res;
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ItemType>>> getItemTypes()
        {
            List<ItemType> res = await _context.ItemTypes
                .ToListAsync();

            if (res == null)
                return NotFound("No ItemTypes found.");

            return res;
        }

        [HttpGet("types/{id}")]
        public async Task<ActionResult<ItemType>> getItemType(ulong id)
        {
            ItemType? res = await _context.ItemTypes
                .FirstOrDefaultAsync(x => 
                    x.Id == id
                );

            if (res == null)
                return NotFound($"ItemType by id \"{id}\" was found.");

            return res;
        }
    }
}
