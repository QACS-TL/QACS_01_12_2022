using _07ThrowingExceptions;
using System;
using Xunit;

namespace XUnitInvoiceTests
{
    public class InvoiceTests
    {
        string invoiceNumber = "123456";
        DateTime invoiceDate = new DateTime(2022, 01, 01);
        decimal grossAmount = 100.00m;
        string customerName = "G. Garvey";
        string description = "3 Packets of Crisps";

        [Fact]
        public void ValidInvoiceDetails()
        {
            //Arrange
            DateTime expectedPaymentDueDate = invoiceDate.AddDays(28);
            decimal expectedNetAmount = 80.00m;
            decimal expectedVATAmount = 20.01m;

            //Act
            Invoice validinvoice = new Invoice(invoiceNumber, invoiceDate, grossAmount, customerName, description);

            //Assert
            Assert.Equal(expectedPaymentDueDate, validinvoice.PaymentDueDate);
            Assert.Equal(expectedNetAmount, validinvoice.NetAmount);
            Assert.Equal(expectedVATAmount, validinvoice.VATAmount);
        }

        [Fact]
        public void InvalidInvoiceDetailsFutureInvoiceDate()
        {
            //Arrange
            DateTime futureDate = new DateTime(2022, 01, 01).AddYears(10);
            Invoice invoice = null;
            string expectedErrorMessage =
                $"Illegal Invoice date! {futureDate:D} is in the future";

            //Act
            IllegalInvoiceDateException ex =
                Assert.Throws<IllegalInvoiceDateException>(
                    () => invoice = new Invoice(
                        invoiceNumber,
                        futureDate,
                        grossAmount,
                        customerName,
                        description));

            //Assert
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        [Fact]
        public void InvalidInvoiceDetailsEarlyPaymentDueDate()
        {
            //Arrange
            DateTime earlyPaymentDueDate = new DateTime(2022, 01, 01).AddYears(-1);
            Invoice validinvoice = null;
            string expectedErrorMessage =
                $"Illegal Invoice date! "
              + $"payment due date of {earlyPaymentDueDate:D} "
              + $"is earlier than invoice date of {invoiceDate:D}";

            //Act
            IllegalInvoiceDateException ex =
                Assert.Throws<IllegalInvoiceDateException>(
                    () => validinvoice = new Invoice(
                        invoiceNumber,
                        invoiceDate,
                        grossAmount,
                        customerName,
                        description,
                        earlyPaymentDueDate));

            //Assert
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

        public static readonly object[][] InvalidData =
        {
            new object[]{
                "123456", 
                new DateTime(2022, 01, 01).AddYears(10), 
                100.00m, 
                "G. Garvey", 
                "3 Packets of Crisps", 
                new DateTime(2022, 01, 28).AddYears(-1),
                $"Illegal Invoice date! {new DateTime(2022, 01, 01).AddYears(10):D} is in the future"
        },
            new object[]{
                "123456", 
                new DateTime(2022, 01, 01), 
                100.00m, 
                "G. Garvey", 
                "3 Packets of Crisps", 
                new DateTime(2022, 01, 01).AddYears(-1),
                $"Illegal Invoice date! payment due date of {new DateTime(2022, 01, 01).AddYears(-1):D} is earlier than invoice date of {new DateTime(2022, 01, 01):D}" },
        };
    [Theory, MemberData(nameof(InvalidData))]
        public void InvalidInvoiceDetailsFutureInvoiceDateX(
            string invoiceNumber, 
            DateTime invoiceDate,
            decimal grossAmount,
            string customerName,
            string description,
            DateTime paymentDueDate,
            string expectedErrorMessage
            )
            {
            //Arrange
            Invoice invoice = null;

            //Act
            IllegalInvoiceDateException ex =
                Assert.Throws<IllegalInvoiceDateException>(
                    () => invoice = new Invoice(
                        invoiceNumber,
                        invoiceDate,
                        grossAmount,
                        customerName,
                        description,
                        paymentDueDate));

            //Assert
            Assert.Equal(expectedErrorMessage, ex.Message);
        }

    }
}
