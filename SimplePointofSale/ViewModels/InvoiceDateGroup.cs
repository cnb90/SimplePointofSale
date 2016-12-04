using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplePointofSale.ViewModels
{
    public class InvoiceDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? InvoiceDate { get; set; }

        public int InvoiceCount { get; set; }
    }
}