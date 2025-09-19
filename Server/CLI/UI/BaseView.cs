namespace CLI.UI;

public abstract class BaseView
{
    protected static Task PauseAsync(string msg = "Press Enter to continue...")
    {
        Console.WriteLine();
        Console.Write(msg);
        Console.ReadLine();
        return Task.CompletedTask;
    }
}