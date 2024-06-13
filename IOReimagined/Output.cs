namespace IOReimagined;

public static class Output
{
    public static void PrintLine(string text, params string[] additional) => IO.PrintLine(text, additional);
    public static void Print(string text, params string[] additional) => IO.Print(text, additional);
    public static void Print(params object[] values) => IO.Print(values);
}
public static partial class IO
{
    public static void PrintLine(string text, params string[] additional)
    {
        Print(text, additional);
        if (EnableStoring) Storage.Add(SpecialChar.EndLine);
        Console.Write('\n');
    }
    public static void Print(string text, params string[] additional)
    {
        Console.Write(text);
        if (EnableStoring)
        {
            Storage.Add(text);
            Storage.AddRange(additional);
        }
        if (additional.Length > 0)
            foreach (string a in additional)
                Console.Write(a);
    }
    public static void Print(params object[] objs)
    {
        if (objs.Length <= 0) return;
        if (EnableStoring) Storage.AddRange(objs);

        foreach (object obj in objs)
        {
            switch (obj)
            {
                case ConsoleColor:
                    ConsoleColor color;
                    try { color = (ConsoleColor)obj; }
                    catch { throw new Exception("Could not parse ConsoleColor"); }
                    Console.ForegroundColor = color;
                    break;
                case string:
                    Console.Write(obj);
                    break;
                case SpecialChar:
                    SpecialChar specialChar;
                    try { specialChar = (SpecialChar)obj; }
                    catch { throw new Exception("Could not parse SpecialChar"); }
                    Console.Write(specialChar.Value);
                    if (specialChar.Value == '\n') Console.ResetColor();
                    break;
                default:
                    Console.Write(obj.ToString());
                    break;
            }
        }
    }
}