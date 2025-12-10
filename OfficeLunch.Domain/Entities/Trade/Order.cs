using OfficeLunch.Domain.Commons;
using OfficeLunch.Domain.Entities.Identity;
using OfficeLunch.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Trade
{
    [Table("Orders")]
    public class Order : AuditableEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Paid;

        public virtual required User User { get; set; }
        public virtual required ICollection<OrderItem> OrderItems { get; set; }
    }
}