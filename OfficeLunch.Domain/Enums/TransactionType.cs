namespace OfficeLunch.Domain.Enums
{
    public enum TransactionType
    {
        Deposit = 1,       // Top-up from SePay
        Payment = 2,       // Order payment
        Refund = 3,        // Order refund
        Transfer = 4,      // P2P Transfer
        Withdraw = 5       // Withdraw to bank
    }
}
