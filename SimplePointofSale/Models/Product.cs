using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplePointofSale.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        //[StringLength(50, MinimumLength = 1)]
        public string Brand { get; set; }
        //[StringLength(50, MinimumLength = 1)]
        [DisplayName("Produce Name")]
        public string ProductName { get; set; }
        [DisplayName("Product Description")]
        public string ProductFullName { get { return Brand + " " + ProductName + ": " + Price.ToString("C"); } }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}