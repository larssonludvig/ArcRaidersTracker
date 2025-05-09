using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Models
{
    [PrimaryKey(nameof(MapId), nameof(MapLootTypeId))]
    public class MapLoot
    {
        public ulong MapId { get; set; }
        public ulong MapLootTypeId { get; set; }
    }
}
