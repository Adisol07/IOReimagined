namespace IOReimagined;

public static class Input
{
    public static string GetString() => IO.GetString();
    public static int GetInt() => IO.GetInt();
    public static char GetChar() => IO.GetChar();
    public static string GetPassword(char passwordChar = '*') => IO.GetPassword(passwordChar);
}
public static partial class IO
{
    public static string GetString()
    {
        string result = Console.ReadLine()!;
        if (EnableStoring) Storage.Add(result);
        return result;
    }
    public static int GetInt()
    {
        if (!int.TryParse(Console.ReadLine(), out int result)) 
            throw new Exception("Value is not int32");
        if (EnableStoring) Storage.Add(result);
        return result;
    }
    public static char GetChar()
    {
        if (!char.TryParse(Console.ReadLine(), out char result)) 
            throw new Exception("Value is not char");
        if (EnableStoring) Storage.Add(result);
        return result;
    }
    public static string GetPassword(char passwordChar = '*')
    {
        string value = "";
        int x = Console.GetCursorPosition().Left;
        int y = Console.GetCursorPosition().Top;
        while (true)
        {
            Console.SetCursorPosition(x, y);
            for (int i = x; i < Console.WindowWidth; i++)
            {
                if (value.Length > i - x) Console.Write(passwordChar);
                else Console.Write(" ");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter) break;
            if (keyInfo.Key == ConsoleKey.Backspace) value = value.Remove(value.Length-1, 1);
            else value += keyInfo.KeyChar;
        }
        if (EnableStoring) Storage.Add(value);
        return value;
    }
}