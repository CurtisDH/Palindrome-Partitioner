using Palindrome_Partitioner.Interfaces;

namespace Palindrome_Partitioner;

public class InputHandler
{
    private readonly string[] _args;
    private readonly IConsoleInput _consoleInput;

    public InputHandler(string[] args, IConsoleInput consoleInput)
    {
        _args = args;
        _consoleInput = consoleInput;
    }

    public string GetUserInput()
    {
        // If args were passed, return only the first argument
        if (_args.Length > 0)
        {
            if (_args.Length > 1)
            {
                Console.WriteLine(
                    $"Multiple arguments were detected! Only considering the first argument: '{_args[0]}'");
            }

            return _args[0];
        }

        // Otherwise we allow the user to enter from console
        string returnString = "";
        bool firstRun = true;
        while (string.IsNullOrWhiteSpace(returnString))
        {
            if (!firstRun)
            {
                Console.WriteLine("Error: Invalid input. The input cannot be null or empty.");
            }

            Console.WriteLine("Provide string for comparison");
            Console.Write(">");
            returnString = _consoleInput.ReadLine();
            firstRun = false;
        }

        return returnString;
    }
}