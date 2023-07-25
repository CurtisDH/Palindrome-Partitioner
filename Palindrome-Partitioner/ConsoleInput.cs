using Palindrome_Partitioner.Interfaces;

namespace Palindrome_Partitioner;

public class ConsoleInput : IConsoleInput
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}