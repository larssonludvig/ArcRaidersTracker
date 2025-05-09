using ArcTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ArcTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Controllers
{
    [ApiController]
    [Route("maps")]
    public class MapController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MapController> _logger;

        public MapController(ILogger<MapController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Map>>> getMaps()
        {
            List<Map> res = await _context.Maps
                .ToListAsync();

            if (res.Count == 0)
                return NotFound("No maps found.");

            return res;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Map>> getMap(ulong id)
        {
            Map? res = await _context.Maps
                .FirstOrDefaultAsync(x =>
                    x.Id == id
                );

            if (res == null)
                return NotFound($"Map by id \"{id}\" not found.");

            return res;
        }

        [HttpGet("events")]
        public async Task<ActionResult<List<MapEvent>>> getMapEvents()
        {
            List<MapEvent> res = await _context.MapEvents
                .ToListAsync();

            if (res.Count == 0)
                return NotFound("No MapEvents found.");

            return res;
        }

        [HttpGet("events/{id}")]
        public async Task<ActionResult<MapEvent>> getMapEvent(ulong id)
        {
            MapEvent? res = await _context.MapEvents
                .FirstOrDefaultAsync(x =>
                    x.Id == id
                );

            if (res == null)
                return NotFound($"MapEvent by id \"{id}\" not found.");

            return res;
        }
    }
}
