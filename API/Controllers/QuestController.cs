using ArcTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ArcTrackerAPI.Data;
using ArcTrackerAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Controllers
{
    [ApiController]
    [Route("quests")]
    public class QuestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<QuestController> _logger;

        public QuestController(ILogger<QuestController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Quest>>> getQuests()
        {
            List<Quest> res = await _context.Quests
                .ToListAsync();

            if (res.Count == 0)
                return NotFound("No quests found.");

            return res;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quest>> getQuest(ulong id)
        {
            Quest? res = await _context.Quests
                .FirstOrDefaultAsync(x =>
                    x.Id == id
                );

            if (res == null)
                return NotFound($"Quest by id \"{id}\" not found.");

            return res;
        }

        [HttpGet("{id}/objectives")]
        public async Task<ActionResult<QuestObjectives>> getQuestObjectives(ulong id)
        {
            QuestObjectives res = new QuestObjectives();
            res.Items = new List<Countable<Item>>();

            res.Objectives = await _context.QuestObjectives
                .Where(x => x.QuestId == id)
                .ToListAsync();

            var items = await _context.QuestItemObjectives
                .Join(_context.Items,
                    objective => objective.ItemId,
                    item => item.Id,
                    (objective, item) => new { objective, item }
                )
                .Where(x => x.objective.QuestId == id)
                .ToListAsync();

            foreach (var item in items)
            {
                res.Items.Add(new Countable<Item> { Entity = item.item, Count = item.objective.Count });
            }

            return res;
        }
    }
}
