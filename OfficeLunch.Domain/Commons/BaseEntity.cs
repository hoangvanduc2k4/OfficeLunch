namespace OfficeLunch.Domain.Commons
{
    // Basic class for entities using Integer ID (Auto-increment)
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    // Basic class for entities using Generic ID (Guid, Long, etc.)
    public abstract class BaseEntity<TKey>
    {
        public required TKey Id { get; set; }
    }
}
