using ArcTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ArcTrackerAPI.Data;
using ArcTrackerAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Controllers
{
    [ApiController]
    [Route("workbenches")]
    public class WorkbenchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<WorkbenchController> _logger;

        public WorkbenchController(ILogger<WorkbenchController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Workbench>>> getWorkbenches()
        {
            List<Workbench> res = await _context.Workbenches
                .ToListAsync();

            if (res.Count == 0)
                return NotFound("No workbenches found.");

            return res;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workbench>> getWorkbench(ulong id)
        {
            Workbench? res = await _context.Workbenches
                .FirstOrDefaultAsync(x =>
                    x.Id == id
                );

            if (res == null)
                return NotFound($"Workbench by id \"{id}\" not found.");

            return res;
        }

        [HttpGet("{id}/cost")]
        public async Task<ActionResult<List<Countable<Item>>>> getWorkbenchCost(ulong id)
        {
            List<Countable<Item>> res = new List<Countable<Item>>();

            var cost = await _context.WorkbenchCosts
                .Join(_context.Items,
                    workbenchCost => workbenchCost.WorkbenchId,
                    item => item.Id,
                    (workbenchCost, item) => new { workbenchCost, item }
                )
                .Where(x => x.workbenchCost.WorkbenchId == id)
                .ToListAsync();

            if (cost.Count == 0)
                return NotFound($"No cost available for \"{id}\"");

            foreach (var item in cost)
            {
                res.Add(new Countable<Item> { Entity = item.item, Count = item.workbenchCost.Count });
            }

            return res;
        }
    }
}
