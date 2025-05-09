using ArcTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ArcTrackerAPI.Data;
using ArcTrackerAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Controllers
{
    [ApiController]
    [Route("recycle")]
    public class RecycleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RecycleController> _logger;

        public RecycleController(ILogger<RecycleController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("to/{id}")]
        public async Task<ActionResult<List<Countable<Item>>>> recycleTo(ulong id)
        {
            List<Countable<Item>> res = new List<Countable<Item>>();

            var recycle = await _context.Recyclables
                .Join(_context.Items,
                    recyclable => recyclable.ReceiveId,
                    item => item.Id,
                    (recyclable, item) => new { recyclable, item }
                )
                .Where(x => x.recyclable.ConsumeId == id)
                .ToListAsync();

            if (recycle.Count == 0)
                return NotFound($"No recycle is logged for item \"{id}\".");

            foreach (var item in recycle)
            {
                res.Add(new Countable<Item> { Entity = item.item, Count = item.recyclable.Count });
            }

            return res;
        }

        [HttpGet("from/{id}")]
        public async Task<ActionResult<List<Item>>> recycleFrom(ulong id)
        {
            List<Item> res = new List<Item>();

            var recycle = await _context.Recyclables
                .Join(_context.Items,
                    recylable => recylable.ConsumeId,
                    item => item.Id,
                    (recyclable, item) => new { recyclable, item}
                )
                .Where(x => x.recyclable.ReceiveId == id)
                .ToListAsync();

            if (recycle.Count == 0)
                return NotFound($"No recycle is logged for item \"{id}\".");

            foreach (var item in recycle)
            {
                res.Add(item.item);
            }

            return res;
        }
    }
}
