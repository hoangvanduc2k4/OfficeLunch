namespace OfficeLunch.Domain.Constants
{
    public static class CacheKeysPrefix
    {
        // Pattern: stock:{dailyMenuId}
        public const string StockPrefix = "stock:";

        // ZSET Key for Kitchen Queue
        public const string KitchenQueue = "kitchen_queue";

    }
}
