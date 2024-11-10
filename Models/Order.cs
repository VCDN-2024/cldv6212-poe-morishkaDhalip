using Cloud2bPOE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cloud2bPOE.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }

        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
