namespace OfficeLunch.Application.DTOs.Wallet
{
    public class DepositWebhookDto
    {
        // Name of the payment gateway sending the webhook (e.g., "MOMO", "BANK", "ZALOPAY")
        public string Gateway { get; set; } = string.Empty;

        // Date and time when the transaction occurred (usually provided as a string from the gateway)
        public string TransactionDate { get; set; } = string.Empty;

        // Bank account number or wallet number that sent the payment
        public string AccountNumber { get; set; } = string.Empty;

        // Transaction description or message (e.g., "NAPTIEN USER123")
        public string Content { get; set; } = string.Empty;

        // Amount of money deposited
        public decimal Amount { get; set; }

        // Bank transaction reference code (unique per transaction)
        public string ReferenceCode { get; set; } = string.Empty;
    }
}
