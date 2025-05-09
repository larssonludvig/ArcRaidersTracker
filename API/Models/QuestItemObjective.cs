using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Models
{
    [PrimaryKey(nameof(QuestId), nameof(ItemId))]
    public class QuestItemObjective
    {
        public ulong QuestId { get; set; }
        public ulong ItemId { get; set; }
        public uint Count { get; set; } = 1;
    }
}
