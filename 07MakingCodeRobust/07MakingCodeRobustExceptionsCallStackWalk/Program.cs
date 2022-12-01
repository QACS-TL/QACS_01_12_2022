using System;
using System.IO;

namespace _07MakingCodeRobustExceptionsCallStackWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CodeToDemonstrateCallStackBeingWalked();
            }
            catch (Exception ex)
            {
                //Not much we can do at this level except kill the app
                Console.WriteLine($"{ex.Message}");
            }

        }

        static void CodeToDemonstrateCallStackBeingWalked()
        {
            //NOTE:
            //We could have checked for the existence of the
            //file before trying to read it, but in situations
            //like this things could still fail (the file could get
            //deleted in the short time between checking for it and
            //reading it).
            bool allOK = ReadAndPrintTheFileWithCodeStackWalk();
            while (allOK == false)
            {
                allOK = ReadAndPrintTheFileWithCodeStackWalk();
            }
            Console.WriteLine("\n All Done. :-)");
        }

        private static bool ReadAndPrintTheFileWithCodeStackWalk()
        {
            string filePath = @"C:\Temp\";
            string fileName;
            GetFileName(out fileName);

            FileStream stream = null;
            StreamReader reader = null;
            FileStream streamX = null;
            try
            {
                ReadAndPrintFileContent(
                    filePath, 
                    fileName, 
                    out stream, 
                    out reader, 
                    out streamX);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
                if (stream != null)
                    stream.Dispose();
                if (streamX != null)
                    stream.Dispose();
            }
            return true;
        }

        private static void GetFileName(out string fileName)
        {
            fileName = @"WarAndPeace.txt";
            Console.WriteLine(
                "Please enter the name of a text (*.txt) file you would "
              + "like to read (or just press enter for War and Peace): ");
            string selection = Console.ReadLine();

            if (!string.IsNullOrEmpty(selection))
                fileName = selection;
        }

        private static void ReadAndPrintFileContent(
            string filePath, 
            string fileName, 
            out FileStream stream, 
            out StreamReader reader, 
            out FileStream streamX)
        {
            stream = new FileStream(
                filePath + fileName, 
                FileMode.Open, 
                FileAccess.Read);
            //Introduced artificial error to demonstrate
            //use of Dispose methods in finally block
            streamX = new FileStream(
                filePath + "listoftextfiles1.txt", 
                FileMode.Create, 
                FileAccess.Write);
            reader = new StreamReader(streamX);

            string text = reader.ReadToEnd();

            Console.WriteLine(text);

            reader.Close();
        }
    }
}
