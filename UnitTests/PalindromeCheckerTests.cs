using System;
using Xunit.Abstractions;

namespace UnitTests;

public class PalindromeCheckerTests : IDisposable
{
    private ITestOutputHelper _output;


    public PalindromeCheckerTests(ITestOutputHelper output)
    {
        _output = output;
    }

    public void Dispose()
    {
    }
}