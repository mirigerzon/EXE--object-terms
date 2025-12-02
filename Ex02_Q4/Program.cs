using System;
using System.Diagnostics;
using System.Threading;

namespace Ex02_Q4
{
    class Program
    {
        static int[] arr;
        static int size = 100_000_000;

        static void Main(string[] args)
        {
            arr = new int[size];

            // 1. שני תהליכונים ניגשים לאזורים שונים (0 עד חצי, חצי עד סוף(
            Thread t1 = new Thread(() => Work(0, size / 2));
            Thread t2 = new Thread(() => Work(size / 2, size));

            Stopwatch sw = new Stopwatch();
            sw.Start();
            t1.Start();
            t2.Start();
            t1.Join(); // מחכים שתהליכון 1 יסיים
            t2.Join(); // מחכים שתהליכון 2 יסיים
            sw.Stop();
            Console.WriteLine($"Scenario A (Separate Areas): {sw.ElapsedMilliseconds} ms");

            // 2. שני תהליכונים ניגשים לכל המערך (חפיפה מלאה)
            // נריץ שוב, כל אחד רץ על הכל
            Thread t3 = new Thread(() => Work(0, size));
            Thread t4 = new Thread(() => Work(0, size));

            sw.Reset();
            sw.Start();
            t3.Start();
            t4.Start();
            t3.Join();
            t4.Join();
            sw.Stop();
            Console.WriteLine($"Scenario B (Overlapping Areas): {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }

        // פונקציית עבודה שמבצעת כתיבה למערך
        static void Work(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                arr[i]++;
            }
        }
    }
}