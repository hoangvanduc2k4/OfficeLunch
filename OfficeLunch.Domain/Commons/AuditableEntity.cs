namespace OfficeLunch.Domain.Commons
{
    public abstract class AuditableEntity : BaseEntity, ISoftDelete
    {
        public required string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        // Implement Soft Delete
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
