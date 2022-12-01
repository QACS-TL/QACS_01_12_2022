using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndParameters
{
    internal static class StringUtils
    {
        public static int WordCount(this string theString)
        {
            return theString.Split(' ').Count();
        }
    }
}
