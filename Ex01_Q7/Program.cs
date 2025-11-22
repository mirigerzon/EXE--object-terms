using System;

struct PointStruct
{
    public int X;
    public int Y;
}

class Program
{
    static int counter = 0;

    static void Main(string[] args)
    {
        try
        {
            Recursion();
        }
        catch (StackOverflowException)
        {
            Console.WriteLine("Stack overflow!");
        }
    }

    static void Recursion()
    {
        // ניתן לשנות את הגדלים של arr ואת מספר המשתנים כדי לבצע ניסוי
        int[] arr = new int[10];

        PointStruct p1, p2, p3, p4;
        PointStruct p5, p6, p7, p8;

        counter++;
        Console.WriteLine($"counter={counter}");

        Recursion(); // קריאה רקורסיבית אינסופית
    }
}
