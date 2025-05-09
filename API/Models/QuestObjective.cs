using System.ComponentModel.DataAnnotations;

namespace ArcTrackerAPI.Models
{
    public class QuestObjective
    {
        [Key]
        public ulong Id { get; set; }
        public ulong QuestId { get; set; }
        public ulong? MapId { get; set; }
        public string? Description { get; set; }
    }
}
