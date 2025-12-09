namespace OfficeLunch.Domain.Constants
{
    public static class Policies
    {
        // Duration in minutes to hold an item in a user's cart before it is released
        public const int ItemHoldDurationMinutes = 10;
        // Duration in minutes to cache the daily menu data
        public const int DailyMenuCacheDurationMinutes = 60;
        // Maximum allowed size for uploaded images in bytes
        public const int MaxImageUploadSize = 5 * 1024 * 1024; // 5 MB
        // Supported currency for transactions
        public const string Currency = "vi-VN";

    }
}
