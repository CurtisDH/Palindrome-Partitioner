using Xunit.Abstractions;

namespace Palindrome_Partitioner;

public class PalindromeChecker : IDisposable
{
    private ITestOutputHelper _output;

    public PalindromeChecker(ITestOutputHelper output)
    {
        _output = output;
    }

    public void Dispose()
    {
    }
}