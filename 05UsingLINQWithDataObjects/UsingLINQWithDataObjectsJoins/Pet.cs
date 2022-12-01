using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingLINQWithDataObjects
{

    public class Pet
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }
        public string Breed { get; set; }
        public int YearOfBirth { get; set; }



        //public override string ToString()
        //{
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append("ID: ");
        //    builder.Append(ID);
        //    builder.Append("\n");
        //    builder.Append("Name: ");
        //    builder.Append(Name);
        //    builder.Append("\n");
        //    builder.Append("AnimalType: ");
        //    builder.Append(AnimalType);
        //    builder.Append("\n");
        //    builder.Append("Breed: ");
        //    builder.Append(Breed);
        //    builder.Append("\n");
        //    builder.Append("YearOfBirth: ");
        //    builder.Append(YearOfBirth);
        //    builder.Append("\n");
        //    builder.Append("OwnerName: ");
        //    builder.Append(OwnerID);
        //    builder.Append("\n");

        //    return builder.ToString();
        //}

    }
}
