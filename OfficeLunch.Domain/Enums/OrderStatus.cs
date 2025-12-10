namespace OfficeLunch.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0,    // Waiting for kitchen
        Cooking = 1,    // Kitchen is preparing
        Ready = 2,      // Ready for pickup
        Completed = 3,  // Picked up by user
        Cancelled = 4   // Cancelled (Refunded)
    }
}
