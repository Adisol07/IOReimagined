using IOReimagined;

namespace DemoConsole1;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Output.Print("Hello ", ConsoleColor.Blue, "world", SpecialChar.EndLine);
            Output.Print("Hello ", ConsoleColor.Blue, "world", ConsoleColor.Yellow, "2", SpecialChar.EndLine);

            Output.Print(ConsoleColor.DarkGray, "Guess a number: ");
            int x = Input.GetInt();
            if (x == 1)
            {
                Output.Print(ConsoleColor.Green, "Congratulations!", SpecialChar.EndLine);
            }
            else
            {
                Output.Print(ConsoleColor.Red, "Try again!", SpecialChar.EndLine);
            }

            Output.Print(ConsoleColor.Gray, "Password: ", ConsoleColor.Green);
            string password = Input.GetPassword('*');
            Output.Print(ConsoleColor.DarkCyan, "Your password is: ", ConsoleColor.Cyan, password, SpecialChar.EndLine);
        }
    }
}