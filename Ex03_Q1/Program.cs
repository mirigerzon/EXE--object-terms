using System;
using System.Diagnostics;
using System.Threading;

namespace Ex03_Q1
{
    public delegate double BinaryOperation(double x, double y);

    public class Operations
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double ApplyOperation(BinaryOperation bOp, double a, double b)
        {
            return bOp(a, b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}