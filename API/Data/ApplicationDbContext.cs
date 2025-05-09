using Microsoft.EntityFrameworkCore;
using ArcTrackerAPI.Models;

namespace ArcTrackerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Recyclable> Recyclables { get; set; }
        public DbSet<ItemRarity> ItemRarities { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<MapEvent> MapEvents { get; set; }
        public DbSet<MapLootType> MapLootsTypes { get; set; }
        public DbSet<MapLoot> MapLoots { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestItemObjective> QuestItemObjectives { get; set; }
        public DbSet<QuestObjective> QuestObjectives { get; set; }
        public DbSet<Workbench> Workbenches { get; set; }
        public DbSet<WorkbenchCost> WorkbenchCosts { get; set; }
        public DbSet<WorkbenchRecipe> WorkbenchRecipes { get; set; }
        public DbSet<WorkbenchRecipeCost> WorkbenchRecipeCosts { get; set; }
    }
}