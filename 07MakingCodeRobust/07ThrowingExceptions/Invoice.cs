using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07ThrowingExceptions
{
    public class Invoice
    {
        const decimal VATRATE = 20;
        public Invoice(
            string invoiceNumber = "123456",
            DateTime invoiceDate = default(DateTime),
            decimal grossAmount = 0.00m,
            string customerName = null,
            string description = null,
            DateTime paymentDueDate = default(DateTime)
        )
        {
            InvoiceNumber = invoiceNumber;
            if (invoiceDate == default(DateTime))
                //Sets default value but overwrites any passed in value
                invoiceDate = DateTime.Today;
            //Invoice date can't be in the future
            else if (invoiceDate > DateTime.Today) 
                throw new IllegalInvoiceDateException(
                    $"Illegal Invoice date! {invoiceDate:D} "
                  + $"is in the future");
            InvoiceDate = invoiceDate;
            GrossAmount = grossAmount;
            CustomerName = customerName;
            Description = description;

            if (paymentDueDate == default(DateTime))
                //Sets default value but overwrites any passed in value
                paymentDueDate = InvoiceDate.AddDays(28); 
            else if (paymentDueDate <= InvoiceDate)
                throw new IllegalInvoiceDateException(
                    $"Illegal Invoice date! "
                  + $"payment due date of {paymentDueDate:D} "
                  + $"is earlier than invoice date of {invoiceDate:D}");

            PaymentDueDate = paymentDueDate;
        }

        //Properties
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal NetAmount {
            get {
                return GrossAmount * (1 - (VATRATE / 100));
            }
        }
        public decimal VATAmount { 
            get {
                return GrossAmount * (VATRATE / 100);
            }
        }
        public decimal GrossAmount { get; set; }
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public DateTime PaymentDueDate { get; set; }
    }
}
