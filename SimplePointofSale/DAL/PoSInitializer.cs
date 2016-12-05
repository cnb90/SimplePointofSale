using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimplePointofSale.Models;

namespace SimplePointofSale.DAL
{
	public class PoSInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<PoSContext>
	{
        protected override void Seed(PoSContext context)
        {
            var customers = new List<Customer>
            {
                new Customer {FName="Nick",LName="Bock",Email="cnb@temple.edu" },
                new Customer {FName="Carson",LName="Alexander",Email="carson@gmail.com" },
                new Customer {FName="Meredith",LName="Alonso",Email="malonso@yahoo.com" },
                new Customer {FName="Arturo",LName="Anand",Email="aanand@outlook.com" },
                new Customer {FName="Gytis",LName="Barzdukas",Email="scrapbook@aol.com" },
                new Customer {FName="Yan",LName="Li",Email="yl1234@mail.com" },
                new Customer {FName="Peggy",LName="Justice",Email="justic@aol.com" },
                new Customer {FName="Laura",LName="Norman",Email="lnorman@tmeple.edu" },
                new Customer {FName="Nino",LName="Olivetto",Email="olive@vt.edu" }
            };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {Brand="Microsoft",ProductName="Office Home & Business 2016",Price=229.99m},
                new Product {Brand="Microsoft",ProductName="Visio 2016",Price=299.99m},
                new Product {Brand="Apple",ProductName="Keynote",Price=19.99m},
                new Product {Brand="Adobe",ProductName="CS6",Price=2999.99m},
                new Product {Brand="Microsoft",ProductName="Age of Empires 2",Price=9.90m},
                new Product {Brand="QuickBooks",ProductName="Desktop",Price=499.99m},
                new Product {Brand="Microsoft",ProductName="Project 2016",Price=589.99m},
                new Product {Brand="Microsoft",ProductName="Office 365 Home Edition",Price=99.99m},
                new Product {Brand="Corel",ProductName="WordPerfect Office X8",Price=99.99m},
                new Product {Brand="Corel",ProductName="WordPerfect Office X8 - Pro",Price=399.99m}
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            var invoices = new List<Invoice>
            {
                new Invoice {CustomerID=1,InvoiceDate=DateTime.Parse("2016-09-01")},
                new Invoice {CustomerID=2,InvoiceDate=DateTime.Parse("2016-09-02")},
                new Invoice {CustomerID=3,InvoiceDate=DateTime.Parse("2016-09-02")},
                new Invoice {CustomerID=4,InvoiceDate=DateTime.Parse("2016-09-05")},
                new Invoice {CustomerID=1,InvoiceDate=DateTime.Parse("2016-09-05")}
            };

            invoices.ForEach(s => context.Invoices.Add(s));
            context.SaveChanges();

            var lines = new List<InvoiceLine>
            {
                new InvoiceLine {InvoiceID=1,ProductID=1,Quantity=1,PriceAtSale=199.99m},
                new InvoiceLine {InvoiceID=5,ProductID=2,Quantity=1,PriceAtSale=89.99m},
                new InvoiceLine {InvoiceID=2,ProductID=1,Quantity=1,PriceAtSale=199.99m},
                new InvoiceLine {InvoiceID=3,ProductID=4,Quantity=1,PriceAtSale=2999.99m},
                new InvoiceLine {InvoiceID=4,ProductID=1,Quantity=1,PriceAtSale=199.99m},
                new InvoiceLine {InvoiceID=1,ProductID=3,Quantity=1,PriceAtSale=19.99m},
                new InvoiceLine {InvoiceID=1,ProductID=4,Quantity=1,PriceAtSale=1999.99m},
                new InvoiceLine {InvoiceID=1,ProductID=5,Quantity=1,PriceAtSale=9.99m}
            };

            lines.ForEach(s => context.InvoiceLines.Add(s));
            context.SaveChanges();
        }
    }
}