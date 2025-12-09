namespace OfficeLunch.Domain.Enums
{
    public enum PaymentMethod
    {
        Cash = 0,           // Cash on delivery
        BankTransfer = 1,   // VietQR / Sepay
        EWallet = 2         // Momo/ZaloPay (Future)
    }
}
