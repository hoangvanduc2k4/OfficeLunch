using OfficeLunch.Domain.Commons;
using OfficeLunch.Domain.Entities.Identity;
using OfficeLunch.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Finance
{
    [Table("WalletTransactions")]
    public class WalletTransaction : BaseEntity<long>
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } // (+) Deposit/Refund, (-) Payment

        [Column(TypeName = "decimal(18,2)")]
        public decimal BalanceAfter { get; set; } // Balance snapshot

        public TransactionType Type { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Description { get; set; }

        [MaxLength(100)]
        public string? ReferenceCode { get; set; } // SePay Code or Order ID

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual required User User { get; set; }
    }
}