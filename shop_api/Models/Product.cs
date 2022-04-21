using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace shop_api.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double? Price { get; set; }
        public double? Weight { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual Category? Category { get; set; }
        public Guid CategoryId { get; set; }
       
    }
}
