using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Palindrome_Partitioner;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests;

public class PartitionerTests : IDisposable
{
    private ITestOutputHelper _output;
    private Partitioner _partitioner;

    public PartitionerTests(ITestOutputHelper output)
    {
        _output = output;
        Setup();
    }

    void Setup()
    {
        _partitioner = new Partitioner();
    }


    [Theory]
    [MemberData(nameof(TestData))]
    public void PartitionTest(string input, List<List<string>> expected)
    {
        var result = _partitioner.Partition(input);

        _output.WriteLine($"Tested string: '{input}'");
        var expectedJson = JsonConvert.SerializeObject(expected);
        _output.WriteLine($"Expected result: {expectedJson}");
        var actualJson = JsonConvert.SerializeObject(result);
        _output.WriteLine($"Actual result: {actualJson}");

        Assert.Equal(expectedJson, actualJson);
    }

    public void Dispose()
    {
        _partitioner = null;
        _output = null;
    }


    private static IEnumerable<object[]> TestData()
    {
        yield return new object[]
        {
            "", new List<List<string>> { new List<string>() }
        };

        yield return new object[]
        {
            "a", new List<List<string>> { new List<string> { "a" } }
        };

        yield return new object[]
        {
            "abc", new List<List<string>> { new List<string> { "a", "b", "c" } }
        };

        yield return new object[]
        {
            "geeks", new List<List<string>>
            {
                new List<string> { "g", "e", "e", "k", "s" },
                new List<string> { "g", "ee", "k", "s" }
            }
        };

        yield return new object[]
        {
            "aab", new List<List<string>>
            {
                new List<string> { "a", "a", "b" },
                new List<string> { "aa", "b" }
            }
        };

        yield return new object[]
        {
            "racecar", new List<List<string>>
            {
                new List<string> { "r", "a", "c", "e", "c", "a", "r" },
                new List<string> { "r", "a", "cec", "a", "r" },
                new List<string> { "r", "aceca", "r" },
                new List<string> { "racecar" }
            }
        };
    }
}