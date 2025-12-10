using OfficeLunch.Domain.Commons;
using OfficeLunch.Domain.Entities.Operation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Master
{
    [Table("Products")]
    public class Product : AuditableEntity
    {
        [Required]
        [MaxLength(200)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual required Category Category { get; set; }

        public virtual required ICollection<DailyMenu> DailyMenus { get; set; }
    }
}