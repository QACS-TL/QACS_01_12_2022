using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07ThrowingExceptions
{
    public class IllegalInvoiceDateException: Exception
    {
        public IllegalInvoiceDateException(
            string message = "Illegal Invoice Date!"
            ):base(message)
        {
            
        }
    }
}
