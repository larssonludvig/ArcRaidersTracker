using System.ComponentModel.DataAnnotations;

namespace ArcTrackerAPI.Models
{
    public class WorkbenchRecipe
    {
        [Key]
        public ulong Id { get; set; }
        public ulong ItemId { get; set; }
        public uint Count { get; set; } = 1;
    }
}
