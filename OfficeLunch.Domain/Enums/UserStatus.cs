namespace OfficeLunch.Domain.Enums
{
    public enum UserStatus
    {
        Inactive = 0,   // Email not verified
        Active = 1,     // Normal status
        Locked = 2,     // Temporarily locked (wrong password attempts)
        Banned = 3      // Permanently banned (policy violation)
    }
}
