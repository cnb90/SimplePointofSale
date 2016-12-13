using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimplePointofSale.Models
{
    public enum PaymentMethod
    {
        Cash,
        Check,
        Credit,
        Debit
    }

    public class Payment
    {
        int PaymentID { get; set; }
        int InvoiceID { get; set; }
        [DisplayFormat(NullDisplayText = "No payment")]
        [DisplayName("Payment Method")]
        public PaymentMethod? PaymentMethod { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}