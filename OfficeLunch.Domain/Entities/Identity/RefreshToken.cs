using OfficeLunch.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeLunch.Domain.Entities.Identity
{
    [Table("RefreshTokens")]
    public class RefreshToken : BaseEntity
    {
        [Required]
        public required string Token { get; set; }

        [Required]
        public required string JwtId { get; set; } // JTI of the Access Token

        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual required User User { get; set; }
    }
}