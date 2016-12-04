using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimplePointofSale.Models
{
    public class Customer
    {
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        // [Required(ErrorMessage ="Please enter a first name.")]
        [DisplayName("First Name")]
        public string FName { get; set; }
        [DisplayName("Last Name")]
        public string LName { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get { return FName + " " + LName; } }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}