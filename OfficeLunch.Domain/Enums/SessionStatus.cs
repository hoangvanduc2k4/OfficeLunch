namespace OfficeLunch.Domain.Enums
{
    public enum SessionStatus
    {
        Open = 0,       // Open for joining and ordering
        Locked = 1,     // Locked by Host (calculating bill), no new orders
        Closed = 2,     // Order submitted to kitchen, session finished
        Cancelled = 3   // Session cancelled
    }
}
