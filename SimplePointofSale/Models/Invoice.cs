using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimplePointofSale.Models
{
    public class Invoice
    {
        [DisplayName("Invoice Number")]
        public int InvoiceID { get; set; }
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }


    }
}