using System;
using System.Collections.Generic;
using System.IO;

namespace _07MakingCodeRobustExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //CodeThatCouldThrowAnException();
            //CodeThatDealsWithFileNotFoundException();
            //CodeThatGivesUserAnotherAttemptIfFileNotFoundExceptionOccurs();
            //CodeThatIncludesAFinallyClause();
            CodeToDemonstrateCallStackBeingWalked();
        }

        static void CodeThatCouldThrowAnException()
        {
            string filePath = @"C:\Temp\";
            string fileName = @"WarAndPeace.txt";

            Console.WriteLine(
                "Please enter the name of a text (*.txt) file you would "
              + "like to read (or just press enter for War and Peace): ");
            string selection = Console.ReadLine();

            if (!string.IsNullOrEmpty(selection))
                fileName = selection;

            FileStream stream;
            StreamReader reader;

            stream = new FileStream(
                filePath + fileName, 
                FileMode.Open, 
                FileAccess.Read);
            reader = new StreamReader(stream);

            string text = reader.ReadToEnd();

            Console.WriteLine(text);

            reader.Close();
            stream.Close();
        
        }

        static void CodeThatDealsWithFileNotFoundException()
        {
            string filePath = @"C:\Temp\";
            string fileName = @"WarAndPeace.txt";

            Console.WriteLine(
                "Please enter the name of a text (*.txt) file you would "
              + "like to read (or just press enter for War and Peace): ");
            string selection = Console.ReadLine();

            if (!string.IsNullOrEmpty(selection))
                fileName = selection;

            FileStream stream;
            StreamReader reader;
            try
            {
                stream = new FileStream(
                    filePath + fileName, 
                    FileMode.Open, 
                    FileAccess.Read);
                reader = new StreamReader(stream);

                string text = reader.ReadToEnd();

                Console.WriteLine(text);

                reader.Close();
                stream.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        static void CodeThatGivesUserAnotherAttemptIfFileNotFoundExceptionOccurs()
        {
            //NOTE:
            //We could have checked for the existence of the
            //file before trying to read it, but in situations
            //like this things could still fail (the file could get
            //deleted in the short time between checking for it and
            //reading it).
            bool allOK = ReadAndPrintTheFile();
            while (allOK == false)
            {
                allOK = ReadAndPrintTheFile();
            }
            Console.WriteLine("\n All Done. :-)");
        }

        private static bool ReadAndPrintTheFile()
        {
            string filePath = @"C:\Temp\";
            string fileName;
            GetFileName(out fileName);

            FileStream stream;
            StreamReader reader;
            try
            {
                stream = new FileStream(
                    filePath + fileName, 
                    FileMode.Open, 
                    FileAccess.Read);
                reader = new StreamReader(stream);

                string text = reader.ReadToEnd();

                Console.WriteLine(text);

                reader.Close();
                stream.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
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

        static void CodeThatIncludesAFinallyClause()
        {
            //NOTE:
            //We could have checked for the existence of the
            //file before trying to read it, but in situations
            //like this things could still fail (the file could get
            //deleted in the short time between checking for it and
            //reading it).
            bool allOK = ReadAndPrintTheFileWithFinally();
            while (allOK == false)
            {
                allOK = ReadAndPrintTheFileWithFinally();
            }
            Console.WriteLine("\n All Done. :-)");
        }

        private static bool ReadAndPrintTheFileWithFinally()
        {
            string filePath = @"C:\Temp\";
            string fileName;
            GetFileName(out fileName);

            FileStream stream = null;
            StreamReader reader = null;
            FileStream streamX = null;
            try
            {
                stream = new FileStream(
                    filePath + fileName, 
                    FileMode.Open, 
                    FileAccess.Read);
                //Introduce artificial error to demonstrate
                //use of Dispose methods in finally block
                streamX = new FileStream(
                    filePath + "listoftextfiles1.txt", 
                    FileMode.Create, 
                    FileAccess.Write); ;
                reader = new StreamReader(streamX);

                string text = reader.ReadToEnd();

                Console.WriteLine(text);

                reader.Close();
                stream.Close();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
            catch (ArgumentException ex)
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
                    streamX.Dispose();
            }
            return true;
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
            catch (ArgumentException ex)
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
            streamX = null;
            //Introduced artificial error to demonstrate
            //use of Dispose methods in finally block
            streamX = new FileStream(
                filePath + "listoftextfiles1.txt",
                FileMode.Create,
                FileAccess.Write);
            reader = new StreamReader(streamX);
            reader = new StreamReader(stream);

            string text = reader.ReadToEnd();

            Console.WriteLine(text);

            reader.Close();
            stream.Close();
        }
    }
}
