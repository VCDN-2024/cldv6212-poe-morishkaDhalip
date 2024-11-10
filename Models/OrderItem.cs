using Cloud2bPOE.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cloud2bPOE.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
