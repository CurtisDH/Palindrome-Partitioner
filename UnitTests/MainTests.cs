using System;
using Palindrome_Partitioner;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests;

public class MainTests : IDisposable
{
    // just need to check cmd line args here
    // i.e.
    // when no string is provided
    // when valid amount of args are met
    // main currently returns -1 for invalid, 0 for valid.
    private ITestOutputHelper _output;

    public MainTests(ITestOutputHelper output)
    {
        _output = output;
    }

    public void Dispose()
    {
        _output = null;
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData(" ", 0)]
    [InlineData("a", 0)]
    [InlineData("aab", 0)]
    [InlineData("geeks", 0)]
    [InlineData("racecar", 0)]
    public void SingleArgTests(string arg, int expectedOutput)
    {
        string[] args = new string[] { arg };

        var status = Program.Main(args);

        _output.WriteLine($"input");
        foreach (var a in args)
        {
            _output.WriteLine($": {a}");
        }

        _output.WriteLine($"Expected result: {expectedOutput}");

        _output.WriteLine($"Actual result: {status}");
        Assert.True(status == expectedOutput);
    }

    [Theory]
    [InlineData("", "", -1)]
    [InlineData(" ", "a", -1)]
    [InlineData("a", "a", -1)]
    [InlineData("aab", "a", -1)]
    [InlineData("geeks", "", -1)]
    [InlineData("racecar", "a", -1)]
    public void MultipleArgTests(string arg, string arg2, int expectedOutput)
    {
        string[] args = new string[] { arg, arg2 };

        var status = Program.Main(args);

        _output.WriteLine($"input");
        foreach (var a in args)
        {
            _output.WriteLine($": {a}");
        }

        _output.WriteLine($"Expected result: {expectedOutput}");

        _output.WriteLine($"Actual result: {status}");
        Assert.True(status == expectedOutput);
    }

    [Theory]
    [InlineData(-1)]
    public void NoArgTests(int expectedOutput)
    {
        string[] args = new string[] { };

        var status = Program.Main(args);

        _output.WriteLine($"input");
        foreach (var a in args)
        {
            _output.WriteLine($": {a}");
        }

        _output.WriteLine($"Expected result: {expectedOutput}");

        _output.WriteLine($"Actual result: {status}");
        Assert.True(status == expectedOutput);
    }
}