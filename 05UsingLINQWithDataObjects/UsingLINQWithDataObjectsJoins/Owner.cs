using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLINQWithDataObjects
{
    class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
        builder.Append("ID: ");
            builder.Append(ID);
            builder.Append("\n");
            builder.Append("Name: ");
            builder.Append(Name);
            builder.Append("\n");
            builder.Append("Address: ");
            builder.Append(Address);
            builder.Append("\n");
            builder.Append("Phone Number: ");
            builder.Append(PhoneNumber);
            builder.Append("\n");

            return builder.ToString();
        }
    }
}
