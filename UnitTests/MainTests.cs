using System;
using System.Collections.Generic;
using Palindrome_Partitioner;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests
{
    public class MainTests : IDisposable
    {
        private ITestOutputHelper _output;

        public MainTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public void Dispose()
        {
            _output = null;
        }

        public static IEnumerable<object[]> TestData()
        {
            return new[]
            {
                new object[] { new string[] { "" }, 0 },
                new object[] { new string[] { " " }, 0 },
                new object[] { new string[] { "a" }, 0 },
                new object[] { new string[] { "aab" }, 0 },
                new object[] { new string[] { "geeks" }, 0 },
                new object[] { new string[] { "racecar" }, 0 },
                new object[] { new string[] { "", "" }, -1 },
                new object[] { new string[] { " ", "a" }, -1 },
                new object[] { new string[] { "a", "a" }, -1 },
                new object[] { new string[] { "aab", "a" }, -1 },
                new object[] { new string[] { "geeks", "" }, -1 },
                new object[] { new string[] { "racecar", "a" }, -1 },
                new object[] { new string[] { }, -1 }
            };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void MainMethodTests(string[] args, int expectedOutput)
        {
            var status = Program.Main(args);

            _output.WriteLine($"Input: {string.Join(", ", args)}");
            _output.WriteLine($"Expected result: {expectedOutput}");
            _output.WriteLine($"Actual result: {status}");

            Assert.True(status == expectedOutput);
        }
    }
}