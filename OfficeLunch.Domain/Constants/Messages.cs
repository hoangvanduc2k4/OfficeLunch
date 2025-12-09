namespace OfficeLunch.Domain.Constants
{
    public static class Messages
    {
        public static class General
        {
            public const string InternalServerError = "An unexpected internal error occurred. Please try again later.";
            public const string BadRequest = "Invalid request.";
            public const string NotFound = "The requested resource was not found.";
            public const string Unauthorized = "You do not have permission to perform this action.";
            public const string Forbidden = "Access denied.";
        }
        public static class Auth
        {
            public const string InvalidCredentials = "Invalid username or password.";
            public const string AccountLocked = "This account has been locked due to policy violations.";
            public const string EmailExists = "This email address is already registered.";
            public const string InvalidToken = "Invalid or expired login session.";
        }
        public static class Menu
        {
            public const string ProductNotFound = "Product not found or has been deleted.";
            public const string DailyMenuClosed = "Today's menu is closed or not yet active.";
            public const string DateExists = "A menu for this date already exists.";
        }

        public static class Order
        {
            public const string OutOfStock = "Sorry, this item is currently out of stock.";
            public const string HoldExpired = "Item hold time has expired. Please select again.";
            public const string SessionClosed = "This ordering session has ended or is already finalized.";
            public const string NotHost = "Only the group Host can submit the order.";
            public const string CartEmpty = "Your cart is empty. Cannot submit order.";
            public const string CannotUpdateCooking = "The kitchen is preparing this item. Cannot cancel or modify.";
        }
        public static class Success
        {
            public const string Created = "Created successfully.";
            public const string Updated = "Updated successfully.";
            public const string Deleted = "Deleted successfully.";
            public const string OrderSubmitted = "Order submitted successfully! The kitchen has received your order.";
            public const string AddedToCart = "Added to cart (Item held for 10 minutes).";
            public const string Restocked = "Stock quantity updated successfully.";
        }
    }
}
