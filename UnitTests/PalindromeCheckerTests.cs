using System;
using Palindrome_Partitioner;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests
{
    public class PalindromeCheckerTests : IDisposable
    {
        private ITestOutputHelper _output;
        private PalindromeChecker _checker;

        public PalindromeCheckerTests(ITestOutputHelper output)
        {
            _output = output;
            Setup();
        }

        void Setup()
        {
            _checker = new PalindromeChecker();
        }

        [Theory]
        [InlineData("", true)] // Empty string
        [InlineData("a", true)] // Single character
        [InlineData("aa", true)] // Two same characters
        [InlineData("ab", false)] // Two different characters
        [InlineData("racecar", true)] // Multi-character palindrome
        [InlineData("hello", false)] // Multi-character non-palindrome
        public void IsPalindromeTest(string inp, bool expected)
        {
            var result = _checker.IsPalindrome(inp, 0, inp.Length - 1);

            _output.WriteLine($"Tested string: '{inp}'");
            _output.WriteLine($"Expected result: {expected}");
            _output.WriteLine($"Actual result: {result}");

            Assert.Equal(expected, result);
        }

        public void Dispose()
        {
            _checker = null;
            _output = null;
        }
    }
}