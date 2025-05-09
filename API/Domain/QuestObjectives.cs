using ArcTrackerAPI.Models;

namespace ArcTrackerAPI.Domain
{
    public class QuestObjectives
    {
        public List<Countable<Item>>? Items { get; set; }
        public List<QuestObjective>? Objectives { get; set; }
    }
}