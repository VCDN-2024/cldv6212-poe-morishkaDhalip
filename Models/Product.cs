using System;
using System.ComponentModel.DataAnnotations;

namespace Cloud2bPOE.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
