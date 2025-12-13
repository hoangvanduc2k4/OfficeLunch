using Microsoft.EntityFrameworkCore;
using OfficeLunch.Domain.Constants;
using OfficeLunch.Domain.Entities.Finance;
using OfficeLunch.Domain.Entities.Identity;
using OfficeLunch.Domain.Entities.Master;
using OfficeLunch.Domain.Entities.Operation;
using OfficeLunch.Domain.Entities.Trade;
using OfficeLunch.Domain.Enums;

namespace OfficeLunch.Infrastructure.Persistence.Seeding
{
    public static class ContextSeed
    {
        public static async Task SeedAsync(OfflineLunchDBContext context)
        {
            // 1. Idempotency Check: If users exist, the DB is already seeded.
            if (await context.Users.AnyAsync()) return;

            // =========================================================================
            // A. SEED USERS (IDENTITY)
            // =========================================================================
            // Standard password for everyone: "Password123!"
            string passwordHash = BCrypt.Net.BCrypt.HashPassword("Password123!");
            var now = DateTime.UtcNow;

            // 1. Administrator
            var admin = new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Email = "admin@officelunch.com",
                FullName = "System Administrator",
                PasswordHash = passwordHash,
                Role = Roles.Admin,
                Balance = 0,
                IsActive = true,
                CreatedAt = now,
                RefreshTokens = new List<RefreshToken>(),
                WalletTransactions = new List<WalletTransaction>(),
                Orders = new List<Order>()
            };

            // 2. Staff (Kitchen/Chef)
            var staff = new User
            {
                Id = Guid.NewGuid(),
                Username = "chef",
                Email = "chef@officelunch.com",
                FullName = "Gordon Ramsay",
                PasswordHash = passwordHash,
                Role = Roles.Staff,
                Balance = 0,
                IsActive = true,
                CreatedAt = now,
                RefreshTokens = new List<RefreshToken>(),
                WalletTransactions = new List<WalletTransaction>(),
                Orders = new List<Order>()
            };

            // 3. Rich User (For Positive Testing: Has money, has orders)
            // Balance logic: 500,000 (Deposit) - 45,000 (Spent) = 455,000
            var richUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_vip",
                Email = "vip@officelunch.com",
                FullName = "Richie Rich",
                PasswordHash = passwordHash,
                Role = Roles.User,
                Balance = 455000,
                IsActive = true,
                CreatedAt = now,
                RefreshTokens = new List<RefreshToken>(),
                WalletTransactions = new List<WalletTransaction>(),
                Orders = new List<Order>()
            };

            // 4. Poor User (For Negative Testing: No money)
            var poorUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_new",
                Email = "newbie@officelunch.com",
                FullName = "John Doe",
                PasswordHash = passwordHash,
                Role = Roles.User,
                Balance = 0,
                IsActive = true,
                CreatedAt = now,
                RefreshTokens = new List<RefreshToken>(),
                WalletTransactions = new List<WalletTransaction>(),
                Orders = new List<Order>()
            };

            await context.Users.AddRangeAsync(admin, staff, richUser, poorUser);
            await context.SaveChangesAsync(); // Save to generate IDs

            // =========================================================================
            // B. SEED MASTER DATA (CATEGORIES & PRODUCTS)
            // =========================================================================
            var catRice = new Category { Name = "Office Rice", IconUrl = "rice.png", Products = new List<Product>(), CreatedAt = now };
            var catDrink = new Category { Name = "Beverages", IconUrl = "drink.png", Products = new List<Product>(), CreatedAt = now };
            var catNoodle = new Category { Name = "Noodles", IconUrl = "noodle.png", Products = new List<Product>(), CreatedAt = now };

            await context.Categories.AddRangeAsync(catRice, catDrink, catNoodle);
            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                // Rice Category
                new Product { Name = "Crispy Chicken Rice", BasePrice = 35000, Description = "Deep fried chicken thigh with rice", CategoryId = catRice.Id, Category = catRice, DailyMenus = new List<DailyMenu>(), CreatedAt = now },
                new Product { Name = "BBQ Pork Ribs Rice", BasePrice = 40000, Description = "Honey glazed pork ribs", CategoryId = catRice.Id, Category = catRice, DailyMenus = new List<DailyMenu>(), CreatedAt = now },
                
                // Noodle Category
                new Product { Name = "Beef Noodle Soup", BasePrice = 45000, Description = "Traditional flavor", CategoryId = catNoodle.Id, Category = catNoodle, DailyMenus = new List<DailyMenu>(), CreatedAt = now },
                new Product { Name = "Rare Beef Pho", BasePrice = 45000, Description = "24h bone broth", CategoryId = catNoodle.Id, Category = catNoodle, DailyMenus = new List<DailyMenu>(), CreatedAt = now },
                
                // Drink Category
                new Product { Name = "Fresh Pepsi", BasePrice = 10000, Description = "Large cup with ice", CategoryId = catDrink.Id, Category = catDrink, DailyMenus = new List<DailyMenu>(), CreatedAt = now },
                new Product { Name = "Iced Tea", BasePrice = 5000, Description = "Refreshing jasmine tea", CategoryId = catDrink.Id, Category = catDrink, DailyMenus = new List<DailyMenu>(), CreatedAt = now }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // =========================================================================
            // C. SEED OPERATIONS (DAILY MENUS)
            // =========================================================================
            var today = DateTime.UtcNow.Date;
            var yesterday = today.AddDays(-1);
            var tomorrow = today.AddDays(1);

            var menus = new List<DailyMenu>
            {
                // 1. Yesterday's Menu (Should not appear on UI)
                new DailyMenu { Date = yesterday, ProductId = products[0].Id, SalePrice = 35000, StockQuantity = 0, Status = 0, Product = products[0], CreatedAt = now },
                
                // 2. Today's Menu (Active for ordering)
                new DailyMenu { Date = today, ProductId = products[0].Id, SalePrice = 35000, StockQuantity = 50, Status = 1, Product = products[0], CreatedAt = now }, // Chicken Rice
                new DailyMenu { Date = today, ProductId = products[2].Id, SalePrice = 45000, StockQuantity = 28, Status = 1, Product = products[2], CreatedAt = now }, // Beef Noodle
                new DailyMenu { Date = today, ProductId = products[4].Id, SalePrice = 10000, StockQuantity = 100, Status = 1, Product = products[4], CreatedAt = now }, // Pepsi

                // 3. Tomorrow's Menu (For "Upcoming" feature)
                new DailyMenu { Date = tomorrow, ProductId = products[1].Id, SalePrice = 40000, StockQuantity = 50, Status = 1, Product = products[1], CreatedAt = now }, // Pork Ribs
            };

            await context.DailyMenus.AddRangeAsync(menus);
            await context.SaveChangesAsync();

            // =========================================================================
            // D. SEED TRADE & FINANCE (ORDERS & TRANSACTIONS)
            // =========================================================================
            // SCENARIO: The "Rich User" deposits money and buys a lunch.

            // 1. Deposit Transaction (Top-up Wallet)
            var depositTx = new WalletTransaction
            {
                Id = 1,
                UserId = richUser.Id,
                Amount = 500000, // +500k
                BalanceAfter = 500000,
                Type = TransactionType.Deposit,
                Description = "Deposit via SePay QR",
                ReferenceCode = "SEPAY_DEP_001",
                CreatedAt = now.AddHours(-5),
                User = richUser
            };
            await context.WalletTransactions.AddAsync(depositTx);

            // 2. Place an Order (Chicken Rice + Pepsi)
            // Total: 35k + 10k = 45k
            var order1 = new Order
            {
                Id = 1,
                UserId = richUser.Id,
                TotalPrice = 45000,
                Status = OrderStatus.Completed, // Already eaten
                PaymentStatus = PaymentStatus.Paid,
                CreatedAt = now.AddHours(-4),
                User = richUser,
                OrderItems = new List<OrderItem>()
            };
            await context.Orders.AddAsync(order1);
            await context.SaveChangesAsync(); // Save to get Order ID

            // 3. Order Items details
            var items1 = new List<OrderItem>
            {
                new OrderItem { OrderId = order1.Id, DailyMenuId = menus[1].Id, Quantity = 1, Price = 35000, Note = "More rice please", Order = order1, DailyMenu = menus[1] },
                new OrderItem { OrderId = order1.Id, DailyMenuId = menus[3].Id, Quantity = 1, Price = 10000, Note = "Less ice", Order = order1, DailyMenu = menus[3] }
            };
            await context.OrderItems.AddRangeAsync(items1);

            // 4. Payment Transaction (Deduct Money)
            var payTx1 = new WalletTransaction
            {
                Id = 2,
                UserId = richUser.Id,
                Amount = -45000, // -45k
                BalanceAfter = 455000, // 500k - 45k = 455k
                Type = TransactionType.Payment,
                Description = $"Payment for Order #{order1.Id}",
                ReferenceCode = $"ORDER_{order1.Id}",
                CreatedAt = now.AddHours(-4),
                User = richUser
            };
            await context.WalletTransactions.AddAsync(payTx1);

            // =========================================================================
            // E. SEED WITHDRAW REQUESTS
            // =========================================================================

            // Case 1: Poor User tries to withdraw (Rejected due to insufficient funds)
            var withdrawReq1 = new WithdrawRequest
            {
                Id = 1,
                UserId = poorUser.Id,
                Amount = 100000,
                BankName = "Chase Bank",
                BankAccount = "000011112222",
                AccountName = "JOHN DOE",
                Status = WithdrawStatus.Rejected,
                AdminNote = "Insufficient balance",
                CreatedAt = now,
                User = poorUser
            };

            // Case 2: Rich User requests withdrawal (Pending admin approval)
            var withdrawReq2 = new WithdrawRequest
            {
                Id = 2,
                UserId = richUser.Id,
                Amount = 50000,
                BankName = "HSBC",
                BankAccount = "999988887777",
                AccountName = "RICHIE RICH",
                Status = WithdrawStatus.Pending,
                CreatedAt = now,
                User = richUser
            };

            await context.WithdrawRequests.AddRangeAsync(withdrawReq1, withdrawReq2);
            await context.SaveChangesAsync();
        }
    }
}