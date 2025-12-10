using OfficeLunch.Domain.Commons;
using OfficeLunch.Domain.Constants;
using OfficeLunch.Domain.Entities.Finance;
using OfficeLunch.Domain.Entities.Trade;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Identity
{
    [Table("Users")]
    public class User : AuditableEntity<Guid>
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        public required string PasswordHash { get; set; }

        [MaxLength(100)]
        public required string FullName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? AvatarUrl { get; set; }

        [Required]
        public string Role { get; set; } = Roles.User;

        // --- INTERNAL WALLET ---
        // ConcurrencyCheck prevents race conditions during balance updates
        [ConcurrencyCheck]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0;

        // Navigation Properties
        public virtual required ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual required ICollection<WalletTransaction> WalletTransactions { get; set; }
        public virtual required ICollection<Order> Orders { get; set; }
    }
}