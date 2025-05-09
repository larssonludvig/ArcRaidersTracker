using System.ComponentModel.DataAnnotations;

namespace ArcTrackerAPI.Models
{
    public class MapEvent
    {
        [Key]
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
