namespace CLI.UI;

public class InputHelper
{
    public static string ReadRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(s)) return s;
            Console.WriteLine("Value is required.");
        }
    }

    public static int ReadIntRequired(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (int.TryParse(s, out var v)) return v;
            Console.WriteLine("Please enter a valid integer.");
        }
    }
}