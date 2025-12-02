using System;

namespace Ex02_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            // בדיקת הקצאת זיכרון
            // ננסה להקצות מערך בגודל המקסימלי האפשרי עבור האינדקס (int.MaxValue)
            // סביר להניח שזה יכשל בגלל מגבלת ה-2GB של .NET

            try
            {
                // ניסיון להקצות מערך ענק (כ-2 מיליארד אינטים = כ-8GB)
                // זה אמור לזרוק OutOfMemoryException בסביבה סטנדרטית
                Console.WriteLine("Attempting to allocate int[int.MaxValue]...");
                int[] hugeArray = new int[int.MaxValue];
                Console.WriteLine("Success!");
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine("Failed to allocate max int array.");
                Console.WriteLine($"Reason: {ex.Message}");
                Console.WriteLine("Explanation: In .NET, default max object size is 2GB.");
            }

            // הקצאה חוקית גדולה (כ-250 מיליון אינטים = כ-1GB) - זה אמור להצליח
            try
            {
                int safeSize = 250000000;
                Console.WriteLine($"\nAttempting to allocate int[{safeSize}] (~1GB)...");
                int[] bigArray = new int[safeSize];
                Console.WriteLine("Success! Allocated ~1GB array.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}