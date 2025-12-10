namespace OfficeLunch.Domain.Constants
{
    public static class Messages
    {
        // --- General Errors ---
        public static class GeneralMsg
        {
            public const string InternalServerError = "An unexpected internal error occurred. Please try again later.";
            public const string BadRequest = "Invalid request.";
            public const string NotFound = "The requested resource was not found.";
            public const string Unauthorized = "You do not have permission to perform this action.";
            public const string Forbidden = "Access denied.";
            public const string ConcurrencyError = "Data has been modified by another user. Please reload and try again.";
        }

        // --- Authentication (Login/Register/Token) ---
        public static class AuthMsg
        {
            public const string InvalidCredentials = "Invalid username or password.";
            public const string AccountLocked = "This account has been locked due to policy violations.";
            public const string EmailExists = "This email address is already registered.";
            public const string InvalidToken = "Invalid access token.";
            public const string RefreshTokenExpired = "Refresh token has expired. Please login again.";
            public const string RefreshTokenRevoked = "This token has been revoked for security reasons.";
            public const string RefreshTokenUsed = "This token has already been used.";
            public const string TokenMismatch = "Token does not match the user identity.";
        }

        // --- Wallet & Finance (NEW) ---
        public static class WalletMsg
        {
            public const string InsufficientBalance = "Your wallet balance is insufficient for this transaction.";
            public const string InvalidAmount = "The amount must be greater than zero.";
            public const string BelowMinimum = "The amount is below the minimum limit.";
            public const string TransferToSelf = "You cannot transfer money to yourself.";
            public const string ReceiverNotFound = "The receiver account was not found.";
            public const string WithdrawPending = "You have a pending withdrawal request. Please wait for it to be processed.";
            public const string DailyLimitExceeded = "You have exceeded your daily transaction limit.";
        }

        // --- Menu & Products ---
        public static class MenuMsg
        {
            public const string ProductNotFound = "Product not found or has been deleted.";
            public const string CategoryNotFound = "Category not found.";
            public const string DailyMenuClosed = "Today's menu is closed or not yet active.";
            public const string DateExists = "A menu for this date already exists.";
        }

        // --- Ordering & Kitchen ---
        public static class OrderMsg
        {
            public const string OutOfStock = "Sorry, this item is currently out of stock.";
            public const string HoldExpired = "Item hold time has expired. Please select again.";
            public const string CartEmpty = "Your cart is empty. Cannot submit order.";
            public const string CannotUpdateCooking = "The kitchen is preparing this item. Cannot cancel or modify.";
            public const string OrderNotFound = "Order not found or does not belong to you.";
            public const string AlreadyCompleted = "This order has already been completed.";
        }

        // --- Success Messages ---
        public static class SuccessMsg
        {
            // CRUD
            public const string Created = "Created successfully.";
            public const string Updated = "Updated successfully.";
            public const string Deleted = "Deleted successfully.";

            // Order
            public const string OrderPlaced = "Order placed successfully! Please wait for the kitchen.";
            public const string OrderCancelled = "Order cancelled. Amount has been refunded to your wallet.";
            public const string AddedToCart = "Added to cart (Item held for 10 minutes).";

            // Wallet
            public const string TransferSuccess = "Money transferred successfully.";
            public const string WithdrawRequested = "Withdrawal request submitted successfully.";
            public const string WithdrawApproved = "Withdrawal request approved.";
            public const string WithdrawRejected = "Withdrawal request rejected. Money refunded to user wallet.";
        }
    }
}
