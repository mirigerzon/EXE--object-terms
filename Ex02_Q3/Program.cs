using System;

namespace Ex02_Q3
{
    class Program
    {
        // א. פונקציה שמחליפה בין שני פריטים במערך לפי אינדקסים
        static void SwapArray(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // ב. פונקציה גנרית שמחליפה בין שני משתנים (דורשת ref)
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            // הדגמה לסעיף א'
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Array before SwapArray: " + string.Join(", ", arr));
            SwapArray(arr, 0, 4);
            Console.WriteLine("Array after SwapArray(0,4): " + string.Join(", ", arr));

            Console.WriteLine();

            // הדגמה לסעיף ב'
            int x = 10, y = 20;
            Console.WriteLine($"Vars before Swap: x={x}, y={y}");
            Swap(ref x, ref y);
            Console.WriteLine($"Vars after Swap: x={x}, y={y}");

            Console.WriteLine();

            // הדגמה לסעיף ג' (שימוש ב-Swap הגנרי על מערך)
            Console.WriteLine("Array before generic Swap: " + string.Join(", ", arr));
            Swap(ref arr[1], ref arr[2]); // החלפה בין אינדקס 1 לאינדקס 2
            Console.WriteLine("Array after generic Swap(arr[1], arr[2]): " + string.Join(", ", arr));

            Console.ReadLine();
        }
    }
}