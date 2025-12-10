using System;

namespace Ex03_Q2_5;

class Program
{
    public class ArrayProcessor
    {
        public delegate void UnaryAction(double a);

        public static void ProcessArray(double[] array, UnaryAction processor)
        {
            foreach (double item in array)
            {
                processor(item);
            }
        }
    }

    //חישוב סכום
    public class SumCalculator
    {
        public double Sum { get; private set; } = 0;

        public void AddToSum(double number)
        {
            Sum += number;
        }
    }
    //חישוב מקסימום
    public class MaxCalculator
    {
        public double Max { get; private set; } = double.NegativeInfinity;

        public void CalculateIfMax(double number)
        {
            if (number > Max)
                Max = number;
        }
    }

    static void Main(string[] args)
    {
        Random rndNum = new Random();
        double[] arr = new double[10];
        for (int i = 0; i < arr.Length; i++)
            arr[i] = rndNum.NextDouble() * 100;

        SumCalculator s = new SumCalculator();
        ArrayProcessor.ProcessArray(arr, s.AddToSum);
        Console.WriteLine("Sum = " + s.Sum);

        MaxCalculator m = new MaxCalculator();
        ArrayProcessor.ProcessArray(arr, m.CalculateIfMax);
        Console.WriteLine("Max = " + m.Max);

        double lambdaSum = 0;
        ArrayProcessor.ProcessArray(arr, x => lambdaSum += x);
        Console.WriteLine("Lambda sum = " + lambdaSum);

        double lambdaMax = double.NegativeInfinity;
        ArrayProcessor.ProcessArray(arr, x =>
        {
            if (x > lambdaMax)
                lambdaMax = x;
        });
        Console.WriteLine("Lambda max = " + lambdaMax);
    }
}
