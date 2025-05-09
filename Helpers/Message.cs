namespace Injector.Helpers;

public class Message
{
    public static void Print(ConsoleColor color, string message)
    {
        ForegroundColor = color;
        WriteLine(message);
        ResetColor();
    }
}
