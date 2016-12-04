using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplePointofSale.Models
{
    public class InvoiceLine
    {
        public int InvoiceLineID { get; set; }
        [DisplayName("Invoice Number")]
        public int InvoiceID { get; set; }
        [DisplayName("Product")]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [DisplayName("Price")]
        public decimal PriceAtSale { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [DisplayName("Total Price")]
        public decimal LineTotal { get { return PriceAtSale * (100m - Discount) / 100m * Quantity; } }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}