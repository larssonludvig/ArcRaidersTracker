using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Models
{
    [PrimaryKey(nameof(WorkbenchRecipeId), nameof(ItemId))]
    public class WorkbenchRecipeCost
    {
        public ulong WorkbenchRecipeId { get; set; }
        public ulong ItemId { get; set; }
        public uint Count { get; set; } = 1;
    }
}
