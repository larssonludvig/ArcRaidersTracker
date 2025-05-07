namespace ArcTrackerAPI.Domain
{
    public class Countable<T>
    {
        public T Entity { get; set; } = default!;
        public uint Count { get; set; } = 0;
    }
}