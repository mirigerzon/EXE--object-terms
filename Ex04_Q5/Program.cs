using System;
using System.Collections.Generic;
using Ex04_Q4;
using Ex04_Q3;

namespace Ex04_Q5;

class Program
{
    static void Main(string[] args)
    {
        List<Fraction> fractions = new List<Fraction>();
        for (int i = 1; i <= 12; i++)
            fractions.Add(new Fraction(i, 12));

        GenericOperationTable<Fraction> additionTable =
            new GenericOperationTable<Fraction>(fractions, fractions, (x, y) => x + y);

        Console.WriteLine("Addition Table 1/12 to 12/12:");
        additionTable.Print();
    }
}
