using System.ComponentModel.DataAnnotations;

namespace Cloud2bPOE.Models
{
    public class OrderItemViewModel
    {
        [Required]
        [Display(Name = "Product")]
        public int ProductID { get; set; }  // ID of the product being ordered

        [Required]
        [Display(Name = "Customer")]
        public int CustomerID { get; set; }  // ID of the customer placing the order

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }  // Quantity of the product

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal UnitPrice { get; set; }  // Price per unit of the product, populated automatically

        public decimal TotalAmount => UnitPrice * Quantity;  // Total amount for the order item, calculated as UnitPrice * Quantity
    }
}
