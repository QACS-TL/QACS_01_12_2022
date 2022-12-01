using System.Text;
namespace MethodsAndParameters
{
    class Program { 

        public static void Main()
        {
            string str1 = "William";
            string str2 = "Harry";
            Console.WriteLine($"Before Swapping: {str1} {str2}");
            SwapStringsByValue(str1, str2);
            Console.WriteLine($"After Swapping: {str1} {str2}");

            for(int i = 0;i < 10000; i++)
            {
                str1 += "******";
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.Append("******");
            }

            str1 = "Eric";
            str2 = "Ernie";
            Console.WriteLine($"Before Swapping: {str1} {str2}");
            SwapStringsByReference(ref str1, ref str2);
            Console.WriteLine($"After Swapping: {str1} {str2}");

            string text = "It was a cold and rainy night. The clouds weren't just crying they were being squeezed like sponges pouring their content in a seemingly unending deluge of wetness";
            int count = text.WordCount();
            Console.WriteLine($"The text contains {count} words"); //28
        }
        public static void SwapStringsByValue(string s1, string s2)
        {
            string temp = s1;
            s1 = s2;
            s2 = temp;
            Console.WriteLine($"Inside the method {s1} {s2}");
        }

        public static void SwapStringsByReference(ref string s1, ref string s2)
        {
            string temp = s1;
            s1 = s2;
            s2 = temp;
            Console.WriteLine($"Inside the method {s1} {s2}");
        }



    }
}