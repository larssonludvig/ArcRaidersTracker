using Microsoft.EntityFrameworkCore;

namespace ArcTrackerAPI.Models
{
    [PrimaryKey(nameof(ConsumeId), nameof(ReceiveId))]
    public class Recyclable
    {
        public ulong ConsumeId { get; set; } 
        public ulong ReceiveId { get; set; } 
        public uint Count { get; set; }
    }
}
