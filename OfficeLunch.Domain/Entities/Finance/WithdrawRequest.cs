using OfficeLunch.Domain.Commons;
using OfficeLunch.Domain.Entities.Identity;
using OfficeLunch.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Finance
{
    [Table("WithdrawRequests")]
    public class WithdrawRequest : AuditableEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        // Bank Info
        [Required]
        public required string BankName { get; set; }
        [Required]
        public required string BankAccount { get; set; }
        [Required]
        public required string AccountName { get; set; }

        public WithdrawStatus Status { get; set; } = WithdrawStatus.Pending;

        public string? AdminNote { get; set; }

        public virtual required User User { get; set; }
    }
}