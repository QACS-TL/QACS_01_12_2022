using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class Example
{
    public static void Main()
    {
        var list = new ConcurrentBag<string>();
        string[] dirNames = { ".", "..\\..\\..", "C:\\" };
        List<Task> tasks = new List<Task>();
        foreach (var dirName in dirNames)
        {
            Task t = Task.Run(() => {
                Random r = new Random();
                foreach (var path in Directory.GetFiles(dirName))
                {
                    Thread.Sleep((int)r.NextInt64(1000, 2000));
                    list.Add(path + ", " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine(path + ", " + System.Threading.Thread.CurrentThread.ManagedThreadId);
                }
            });
            tasks.Add(t);
        }

        Task.WaitAll(tasks.ToArray());
        foreach (Task t in tasks)
            Console.WriteLine("Task {0} Status: {1}", t.Id, t.Status);

        Console.WriteLine("Number of files read: {0}", list.Count);

        foreach(string item in list){
            Console.WriteLine(item);
        }
    }
}
// The example displays output like the following:
//       Task 1 Status: RanToCompletion
//       Task 2 Status: RanToCompletion
//       Number of files read: 23