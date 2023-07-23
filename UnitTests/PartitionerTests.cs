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


    // xunit arguments have to be constant expressions & cant be complex types so serializing with json is my quick
    // workaround. // TODO if theres time refactor this
    [Theory]
    [InlineData("", "[[]]")] // test empty string, 
    [InlineData("a", "[[\"a\"]]")] // single character
    [InlineData("abc", "[[\"a\",\"b\",\"c\"]]")] // string with all distinct chars
    [InlineData("geeks",
        "[[\"g\",\"e\",\"e\",\"k\",\"s\"]," +
        "[\"g\",\"ee\",\"k\",\"s\"]]")] // Multiple partitions - from brief
    [InlineData("aab", "[[\"a\",\"a\",\"b\"],[\"aa\",\"b\"]]")] // Multiple partitions - from brief
    [InlineData("racecar",
        "[[\"r\",\"a\",\"c\",\"e\",\"c\",\"a\",\"r\"]," +
        "[\"r\",\"a\",\"cec\",\"a\",\"r\"]," +
        "[\"r\",\"aceca\",\"r\"],[\"racecar\"]]")] // Multiple partitions
    public void PartitionTest(string input, string expectedJson)
    {
        var expected = JsonConvert.DeserializeObject<List<List<string>>>(expectedJson);
        var result = _partitioner.Partition(input);

        _output.WriteLine($"Tested string: '{input}'");
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
}