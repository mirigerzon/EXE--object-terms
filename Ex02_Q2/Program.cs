using System;
using System.Diagnostics;

namespace Ex02_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 100_000_000;
            int[] arr = new int[size];

            // אתחול ראשוני
            for (int i = 0; i < size; i++) arr[i] = 1;

            Stopwatch sw = new Stopwatch();
            long sum = 0;

            // מדידה 1: גישה רציפה
            sw.Start();
            for (int i = 0; i < size; i++)
            {
                sum += arr[i];
            }
            sw.Stop();
            Console.WriteLine($"Sequential Access Time: {sw.ElapsedMilliseconds} ms");

            // מדידה 2: גישה מרוחקת
            // חשוב: מבצעים את אותו מספר גישות (size פעמים) אך בקפיצות
            sw.Reset();
            sum = 0;
            int jump = 1000;
            int index = 0;

            sw.Start();
            for (int k = 0; k < size; k++)
            {
                sum += arr[index];
                index += jump;
                // אם חרגנו מהמערך, נחזור להתחלה (מודולו)
                if (index >= size) index = index % size;
            }
            sw.Stop();
            Console.WriteLine($"Random/Distant Access Time: {sw.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}