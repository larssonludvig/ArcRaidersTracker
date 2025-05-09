using System.ComponentModel.DataAnnotations;

namespace ArcTrackerAPI.Models
{
    public class Workbench
    {
        [Key]
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public uint Tier { get; set; } = 1;
    }
}
