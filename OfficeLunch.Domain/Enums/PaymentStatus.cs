namespace OfficeLunch.Domain.Enums
{
    public enum PaymentStatus
    {
        Unpaid = 0,
        Paid = 1,       // Deducted from wallet
        Refunded = 2    // Returned to wallet
    }
}
