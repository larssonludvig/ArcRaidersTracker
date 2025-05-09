using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Models
{
    [PrimaryKey(nameof(WorkbenchId), nameof(ItemId))]
    public class WorkbenchCost
    {
        public ulong WorkbenchId { get; set; }
        public ulong ItemId { get; set; }
        public uint Count { get; set; } = 1;
    }
}
