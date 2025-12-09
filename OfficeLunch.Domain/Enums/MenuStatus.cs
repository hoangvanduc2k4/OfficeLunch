namespace OfficeLunch.Domain.Enums
{
    public enum MenuStatus
    {
        Draft = 0,      // Admin is editing, not visible to users
        Active = 1,     // Visible to users for ordering
        Closed = 2,     // Closed for the day
        Archived = 3    // Old history
    }
}
