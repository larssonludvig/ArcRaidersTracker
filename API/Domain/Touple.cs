namespace ArcTrackerAPI.Domain
{
    public class Touple<T, V>
    {
        public T Entity1 { get; set; } = default!;
        public V Entity2 { get; set; } = default!;
    }
}