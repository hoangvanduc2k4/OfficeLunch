using OfficeLunch.Domain.Commons;
using OfficeLunch.Domain.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Trade
{
    [Table("OrderItems")]
    public class OrderItem : BaseEntity
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("DailyMenu")]
        public int DailyMenuId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Snapshot price

        [MaxLength(200)]
        public string? Note { get; set; }

        public virtual required Order Order { get; set; }
        public virtual required DailyMenu DailyMenu { get; set; }
    }
}