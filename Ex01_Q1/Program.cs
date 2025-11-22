using System;

// Class: Reference Type
public class MyClass
{
    public int Value { get; set; }
    public MyClass(int value) { Value = value; }
}

// Struct: Value Type
public struct MyStruct
{
    public int Value { get; set; }
    public MyStruct(int value) { Value = value; }
}

internal class Program
{
    public static void ChangeStructByValue(MyStruct s)
    {
        s.Value = 99;
        Console.WriteLine($"Inside ChangeStructByValue: {s.Value}");
    }
    public static void ChangeStructByRef(ref MyStruct s)
    {
        s.Value = 500;
    }

    public static void ChangeClassByReference(MyClass c)
    {
        c.Value = 99;
    }

    static void Main(string[] args)
    {
        // 1. א. הדגמה 1: השמה בין שני משתנים ושינוי אחד מהם
        // Class - Reference Type (שני המשתנים מצביעים לאותו אובייקט)
        MyClass classA = new MyClass(10);
        MyClass classB = classA;
        classA.Value = 20; // השינוי ב-classA משפיע על classB
        Console.WriteLine($"\n--- Class (Reference Type) - Assignment ---");
        Console.WriteLine($"classA={classA.Value}, classB={classB.Value}"); // פלט: 20, 20

        // Struct - Value Type (העתקת ערך יוצרת עותק נפרד)
        MyStruct structA = new MyStruct(10);
        MyStruct structB = structA;
        structA.Value = 20; // השינוי ב-structA לא משפיע על structB
        Console.WriteLine($"\n--- Struct (Value Type) - Assignment ---");
        Console.WriteLine($"structA={structA.Value}, structB={structB.Value}"); // פלט: 20, 10

        // 1. א. הדגמה 2: העברה לפונקציה ושינוי בתוך הפונקציה
        // Struct: העברה by-value
        MyStruct structC = new MyStruct(100);
        ChangeStructByValue(structC);
        Console.WriteLine($"\n--- Struct (By-Value to function) ---");
        Console.WriteLine($"structC after call: {structC.Value}"); // פלט: 100 (לא השתנה)

        // Class: העברה by-reference
        MyClass classD = new MyClass(100);
        ChangeClassByReference(classD);
        Console.WriteLine($"\n--- Class (By-Reference to function) ---");
        Console.WriteLine($"classD after call: {classD.Value}"); // פלט: 99 (השתנה)

        // 1. ב. שינוי Struct באמצעות ref [cite: 17, 18]
        MyStruct structE = new MyStruct(100);
        ChangeStructByRef(ref structE); // חייבים להשתמש ב-ref גם כאן
        Console.WriteLine($"\n--- Struct (By-Ref to function) ---");
        Console.WriteLine($"structE after ref call: {structE.Value}"); // פלט: 500 (השתנה)
    }
}