namespace OfficeLunch.Domain.Enums
{
    public enum WithdrawStatus
    {
        Pending = 0,    // Waiting for admin approval
        Approved = 1,   // Money transferred
        Rejected = 2    // Request denied (Refunded)
    }
}
