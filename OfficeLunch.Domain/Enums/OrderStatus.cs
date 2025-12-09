namespace OfficeLunch.Domain.Enums
{
    public enum OrderStatus
    {
        Draft = 0,      // Item added to cart, not submitted
        Pending = 1,    // Submitted by Host, waiting for Kitchen
        Cooking = 2,    // Kitchen accepted, currently cooking
        Ready = 3,      // Cooked, waiting for pickup/delivery
        Completed = 4,  // Delivered/Picked up
        Cancelled = 5   // Cancelled by Host or Kitchen (Out of stock)
    }
}
