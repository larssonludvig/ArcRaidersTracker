using System.ComponentModel.DataAnnotations;

namespace ArcTrackerAPI.Models
{
    public class Item
    {
        [Key]
        public ulong Id { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public string? Description { get; set; } 
        public bool Recyclable { get; set; } = false; 
        public bool Sellable { get; set; } = false; 
        public uint SellPrice { get; set; } = 0; 
        public bool Repairable { get; set; } = false; 
        public uint RepairCost { get; set; } = 0; 
        private uint StackSize { get; set; } = 1;
    }
}
