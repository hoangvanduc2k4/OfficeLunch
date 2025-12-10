using OfficeLunch.Domain.Commons;
using OfficeLunch.Domain.Entities.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Operation
{
    [Table("DailyMenus")]
    public class DailyMenu : AuditableEntity
    {
        public DateTime Date { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int StockQuantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        public int Status { get; set; } = 1;

        public virtual required Product Product { get; set; }
    }
}