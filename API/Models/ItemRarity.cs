using System.ComponentModel.DataAnnotations;

namespace ArcTrackerAPI.Models
{
    public class ItemRarity
    {
        [Key]
        public ulong Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Colour { get; set; } = "000000";
    }
}
