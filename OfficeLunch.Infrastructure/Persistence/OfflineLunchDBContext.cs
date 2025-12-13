using Microsoft.EntityFrameworkCore;
using OfficeLunch.Domain.Entities.Finance;
using OfficeLunch.Domain.Entities.Identity;
using OfficeLunch.Domain.Entities.Master;
using OfficeLunch.Domain.Entities.Operation;
using OfficeLunch.Domain.Entities.Trade;

namespace OfficeLunch.Infrastructure.Persistence
{
    public class OfflineLunchDBContext : DbContext
    {
        public OfflineLunchDBContext(DbContextOptions<OfflineLunchDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        public DbSet<WithdrawRequest> WithdrawRequests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DailyMenu> DailyMenus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Email).IsUnique();
                e.Property(x => x.Balance).HasColumnType("decimal(18,2)").IsConcurrencyToken();
                e.Property(x => x.Username).IsRequired().HasMaxLength(50);
                e.Property(x => x.PasswordHash).IsRequired();
                e.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            });

            builder.Entity<RefreshToken>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Token).IsRequired();
                e.Property(x => x.JwtId).IsRequired();
                e.HasOne(x => x.User)
                 .WithMany(u => u.RefreshTokens)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<WalletTransaction>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.ReferenceCode).IsUnique();
                e.Property(x => x.Amount).HasColumnType("decimal(18,2)");
                e.Property(x => x.BalanceAfter).HasColumnType("decimal(18,2)");
                e.Property(x => x.Description).IsRequired().HasMaxLength(200);
                e.HasOne(x => x.User)
                 .WithMany(u => u.WalletTransactions)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<WithdrawRequest>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Amount).HasColumnType("decimal(18,2)");
                e.Property(x => x.BankName).IsRequired();
                e.Property(x => x.BankAccount).IsRequired();
                e.Property(x => x.AccountName).IsRequired();
                e.HasOne(x => x.User)
                 .WithMany()
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Category>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<Product>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).IsRequired().HasMaxLength(200);
                e.Property(x => x.BasePrice).HasColumnType("decimal(18,2)");
                e.Property(x => x.Description).HasMaxLength(500);
                e.HasOne(x => x.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(x => x.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<DailyMenu>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Date);
                e.HasIndex(x => new { x.Date, x.ProductId }).IsUnique();
                e.Property(x => x.SalePrice).HasColumnType("decimal(18,2)");
                e.HasOne(x => x.Product)
                 .WithMany(p => p.DailyMenus)
                 .HasForeignKey(x => x.ProductId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Order>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.UserId);
                e.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");
                e.HasOne(x => x.User)
                 .WithMany(u => u.Orders)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<OrderItem>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Price).HasColumnType("decimal(18,2)");
                e.Property(x => x.Note).HasMaxLength(200);
                e.HasOne(x => x.Order)
                 .WithMany(o => o.OrderItems)
                 .HasForeignKey(x => x.OrderId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(x => x.DailyMenu)
                 .WithMany()
                 .HasForeignKey(x => x.DailyMenuId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}