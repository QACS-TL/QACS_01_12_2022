using System;

namespace _07ThrowingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime paymentDueDate = new DateTime(2022, 01, 28);

            string invoiceNumber = "123456";
            DateTime invoiceDate = new DateTime(2022, 01, 01);
            decimal grossAmount = 100.00m;
            string customerName = "G. Garvey";
            string description = "3 Packets of Crisps";
            //Invoice date and payment due date both ok
            try
            {
                paymentDueDate = new DateTime(2022, 01, 28);

                Invoice validinvoice = new Invoice(invoiceNumber,
                    invoiceDate,
                    grossAmount,
                    customerName,
                    description,
                    paymentDueDate
                );
                Console.WriteLine(
                    $"Valid Invoice:\n "
                  + $"Invoice Date: {validinvoice.InvoiceDate:D}, "
                  + $"PaymentDueDate: {validinvoice.PaymentDueDate:D}"
                  + $"\n Gross: {validinvoice.GrossAmount:C}, "
                  + $"Net: {validinvoice.NetAmount:C}, "
                  + $"VAT: {validinvoice.VATAmount:C}\n\n");
            }
            catch (IllegalInvoiceDateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Future date
            try
            {
                DateTime futureDate = new DateTime(2022, 01, 01).AddYears(1);
                Invoice invalidinvoice = new Invoice(
                    invoiceNumber,
                    futureDate,
                    grossAmount,
                    customerName,
                    description,
                    paymentDueDate
                );
                //Should not be reached
                Console.WriteLine(
                    $"invalidinvoice - Invoice Date: {invalidinvoice.InvoiceDate}, "
                  + $"PaymentDueDate: {invalidinvoice.PaymentDueDate}");

            }
            catch (IllegalInvoiceDateException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Payment Due Date Earlier than Invoice Date
            try
            {
                DateTime earlyPaymentDueDate = 
                    new DateTime(2022, 01, 01).AddYears(-1);
                Invoice invalidinvoice = new Invoice(
                    invoiceNumber,
                    invoiceDate,
                    grossAmount,
                    customerName,
                    description,
                    earlyPaymentDueDate
                );
                //Should not be reached
                Console.WriteLine(
                    $"invalidinvoice - Invoice Date: {invalidinvoice.InvoiceDate:D}, "
                  + $"PaymentDueDate: {invalidinvoice.PaymentDueDate:D}");
            }
            catch (IllegalInvoiceDateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
