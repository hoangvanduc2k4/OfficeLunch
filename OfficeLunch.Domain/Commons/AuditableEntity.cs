namespace OfficeLunch.Domain.Commons
{
    // Adds tracking columns + Soft Delete flag
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public abstract class AuditableEntity<TKey> : BaseEntity<TKey>
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
