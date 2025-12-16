using System;
using System.Collections.Generic;

namespace Ex04_Q4;

public class Fraction
{
    public int Numerator { get; }
    public int Denominator { get; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");

        int gcd = Gcd(Math.Abs(numerator), Math.Abs(denominator));
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    public override string ToString() => $"{Numerator}/{Denominator}";

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int commonDenominator = f1.Denominator * f2.Denominator;
        int newNumerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
        return new Fraction(newNumerator, commonDenominator);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int commonDenominator = f1.Denominator * f2.Denominator;
        int newNumerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
        return new Fraction(newNumerator, commonDenominator);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        return new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        if (f2.Numerator == 0)
            throw new DivideByZeroException("Cannot divide by a fraction with zero numerator.");
        return new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
    }

    public static bool operator ==(Fraction a, Fraction b) =>
           a.Numerator == b.Numerator && a.Denominator == b.Denominator;

    public static bool operator !=(Fraction a, Fraction b) => !(a == b);

    public static bool operator <(Fraction a, Fraction b) =>
        a.Numerator * b.Denominator < b.Numerator * a.Denominator;

    public static bool operator >(Fraction a, Fraction b) =>
        a.Numerator * b.Denominator > b.Numerator * a.Denominator;

    public override bool Equals(object obj) =>
        obj is Fraction f && this == f;

    public override int GetHashCode() =>
        HashCode.Combine(Numerator, Denominator);

    public int CompareTo(Fraction other) =>
        this < other ? -1 : (this > other ? 1 : 0);
}

class Program
{
    static void Main(string[] args)
    {
        List<Fraction> row_values = new List<Fraction>();
        for (int i = 1; i <= 4; i++)
            row_values.Add(new Fraction(1, i));

        List<Fraction> col_values = new List<Fraction>();
        for (int i = 1; i <= 4; i++)
            col_values.Add(new Fraction(1, i));

        GenericOperationTable<Fraction> t1 =
            new GenericOperationTable<Fraction>(row_values, col_values, (x, y) => x + y);

        GenericOperationTable<Fraction> t2 =
            new GenericOperationTable<Fraction>(row_values, col_values, (x, y) => x - y);

        Console.WriteLine("Addition Table:");
        t1.Print();

        Console.WriteLine("\nSubtraction Table:");
        t2.Print();
    }
}
