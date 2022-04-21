using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace shop_api.Models
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartItem { get; set; }
        public int? Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual Product? Product { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
