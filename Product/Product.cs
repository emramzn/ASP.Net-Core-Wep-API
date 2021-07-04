using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }
        [StringLength(100)]
        [Required]
        public string productTitle { get; set; }
        [StringLength(250)]
        [Required]
        public string productDesc { get; set; }
        [Range(0.00,9999.00)]
        [Required]
        public decimal productPrice { get; set; }
    }
}
