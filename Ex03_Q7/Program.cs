using System;
using System.Collections.Generic;

namespace Ex03_Q7;

public class GenericOperationTable<T>
{
    public delegate T OpFunc(T x, T y);

    private List<T> row_values;
    private List<T> col_values;
    private OpFunc op;

    public GenericOperationTable(List<T> rows, List<T> cols, OpFunc operation)
    {
        row_values = rows;
        col_values = cols;
        op = operation;
    }
    public void Print()
    {
        const int cellWidth = 20;

        Console.Write("".PadLeft(cellWidth));
        foreach (var col in col_values)
        {
            Console.Write(col.ToString().PadLeft(cellWidth));
        }
        Console.WriteLine();

        foreach (var row in row_values)
        {
            Console.Write(row.ToString().PadLeft(cellWidth));

            foreach (var col in col_values)
            {
                T result = op(row, col);
                Console.Write(result.ToString().PadLeft(cellWidth));
            }

            Console.WriteLine();
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        List<double> row_values = new List<double>();
        for (int i = 1; i <= 4; i++)
            row_values.Add(1.0 / i);

        List<double> col_values = new List<double>();
        for (int i = 1; i <= 4; i++)
            col_values.Add(1.0 / i);

        GenericOperationTable<double> t1 =
            new GenericOperationTable<double>(row_values, col_values, (x, y) => x + y);

        t1.Print();
    }
}

