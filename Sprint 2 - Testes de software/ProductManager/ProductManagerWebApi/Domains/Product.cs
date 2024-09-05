using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagerWebApi.Domains
{
    [Index(nameof(Product.Name), IsUnique = true)]
    public class Product
    {
        [Key]
        public Guid IdProduct { get; set; }

        //[Required]
        [Column(TypeName = "VARCHAR(80)")]
        public string? Name { get; set; }

        //[Required]
        [Column(TypeName = "DECIMAL(12, 2)")]
        public decimal Price { get; set; }
    }
}