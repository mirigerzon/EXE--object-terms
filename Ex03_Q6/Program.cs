using System;

namespace Ex03_Q6;

public class OperationTable
{
    public int start_row;
    public int end_row;
    public int start_col;
    public int end_col;
    private BinaryOp op;

    public delegate int BinaryOp(int a, int b);

    public OperationTable(int start_row, int end_row, int start_col, int end_col, BinaryOp operation)
    {
        this.start_row = start_row;
        this.end_row = end_row;
        this.start_col = start_col;
        this.end_col = end_col;
        this.op = operation;
    }

    public void print()
    {
        for (int i = start_row; i <= end_row; i++)
        {
            for (int j = start_col; j <= end_col; j++)
            {
                int result = op(i, j);
                Console.Write(result.ToString().PadLeft(5));
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        OperationTable.BinaryOp multiply = (a, b) => a * b;

        OperationTable table = new OperationTable(
            start_row: 1,
            end_row: 10,
            start_col: 1,
            end_col: 10,
            operation: multiply
        );

        table.print();
    }
}
