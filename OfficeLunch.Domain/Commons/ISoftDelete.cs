namespace OfficeLunch.Domain.Commons
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
        void UndoDelete();
    }
}
