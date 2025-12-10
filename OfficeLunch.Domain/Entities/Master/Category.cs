using OfficeLunch.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Master
{
    [Table("Categories")]
    public class Category : AuditableEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        public string? IconUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual required ICollection<Product> Products { get; set; }
    }
}