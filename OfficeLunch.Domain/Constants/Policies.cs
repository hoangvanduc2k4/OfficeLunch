namespace OfficeLunch.Domain.Constants
{
    public static class Policies
    {
        // --- ORDERING & SHOPPING ---

        // Time to hold stock in Redis when user adds item to cart (10 Minutes)
        public const int ItemHoldDurationMinutes = 10;

        // Maximum quantity of a single product per order (Prevent hoarding)
        public const int MaxQuantityPerItem = 50;

        // --- WALLET & FINANCE ---

        // Minimum amount allowed for Top-up (Deposit) via SePay
        public const decimal MinDepositAmount = 10000; // 10k VND

        // Minimum amount allowed for Withdrawal request
        public const decimal MinWithdrawAmount = 50000; // 50k VND

        // Maximum amount allowed for Withdrawal (Security limit)
        public const decimal MaxWithdrawAmount = 5000000; // 5M VND

        // Minimum amount for P2P Transfer
        public const decimal MinTransferAmount = 5000; // 5k VND


        public const decimal MaxTransferAmount = 10000000; // 10M VND

        // Default Currency Locale for formatting
        public const string CurrencyLocale = "vi-VN";

        // --- SYSTEM & CACHE ---

        // Duration to cache the Daily Menu (Menu rarely changes during the day)
        public const int DailyMenuCacheHours = 12;

        // Max file size for Product Image upload (5MB)
        public const int MaxImageFileSize = 5 * 1024 * 1024;

    }
}
