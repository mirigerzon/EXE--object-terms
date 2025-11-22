using System;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // שאלה 5 – חישוב עצרת
            int number = 10;
            long factorial = MathUtils.Factorial(number);
            Console.WriteLine($"{number}!={factorial}");

            // שאלה 6 – ניסוי הקצאות זיכרון
            MemoryAllocationExperiment();
        }

        public static void MemoryAllocationExperiment()
        {
            long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

            int[] intArray = new int[10000];
            long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

            double[] doubleArray = new double[10000];
            long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

            string[] stringArray = new string[10000];
            long afterStringArray = GC.GetAllocatedBytesForCurrentThread();

            Console.WriteLine($"Baseline Memory: {baselineMemory} bytes");
            Console.WriteLine($"Int Array Allocation: {afterIntArray - baselineMemory} bytes");
            Console.WriteLine($"Double Array Allocation: {afterDoubleArray - afterIntArray} bytes");
            Console.WriteLine($"String Array Allocation: {afterStringArray - afterDoubleArray} bytes");
        }
    }

    class MathUtils
    {
        public static long Factorial(int number)
        {
            long result = 1;

            for (int i = number; i >= 1; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}
