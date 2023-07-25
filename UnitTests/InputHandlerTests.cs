using System;
using System.Collections.Generic;
using Moq;
using Palindrome_Partitioner;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests;

public class InputHandlerTests : IDisposable
{
    private ITestOutputHelper _output;
    private Mock<IConsoleInput> _consoleInputMock;

    public InputHandlerTests(ITestOutputHelper output)
    {
        _output = output;
        _consoleInputMock = new Mock<IConsoleInput>();
    }


    [Theory]
    [MemberData(nameof(TestData))]
    public void GetUserInputTest(string[] args, string consoleInput, string expected)
    {
        _output.WriteLine($"Running test with Args: {string.Join(", ", args)}, Console Input: {consoleInput}");

        // split the consoleInput string into separate inputs
        // doing this so we can simulate a series of entries as well as
        // a null or white space entry as the input handler loops
        var consoleInputsQueue = new Queue<string>(consoleInput.Split('|'));


        // We use a queue so that we can simulate a series of user inputs
        if (consoleInputsQueue.Count > 0)
        {
            // If the queue has elements, we set up the mock IConsoleInput to return a new line of input every time ReadLine() is called
            // This simulates the user entering a new line of input for each call to ReadLine().
            _consoleInputMock.Setup(i => i.ReadLine())
                .Returns(() => consoleInputsQueue.Dequeue())
                .Callback(() =>
                {
                    if (consoleInputsQueue.Count == 0)
                    {
                        // If the queue is empty, we change the mock setup to return null for subsequent calls to ReadLine()
                        // This simulates the behavior of Console.ReadLine() when it reaches the end of the input stream
                        // (i.e., when the user stops providing input).
                        _consoleInputMock.Setup(i => i.ReadLine()).Returns((string)null);
                    }
                });
        }
        else
        {
            // If the queue is initially empty, we set up the mock IConsoleInput to return null for all calls to ReadLine().
            // This simulates the behavior of Console.ReadLine() when it reaches the end of the input stream without any user input.
            _consoleInputMock.Setup(i => i.ReadLine()).Returns((string)null);
        }

        var inputHandler = new InputHandler(args, _consoleInputMock.Object);

        var result = inputHandler.GetUserInput();


        _output.WriteLine($"Expected: {expected}, Got: {result}");
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> TestData()
    {
        return new[]
        {
            // structure is as follows: command line args, simulated console input, expected output
            // using '|' allows us to split the input. See the above test implementation where it is explained in detail
            new object[] { new string[] { }, "UserInput", "UserInput" }, // when no args, return console input
            new object[]
                { new string[] { "CommandLineArg" }, "", "CommandLineArg" }, // when args present, return first arg
            new object[]
            {
                new string[] { "MultiCommandLineArgs", "this should be ignored" }, "", "MultiCommandLineArgs"
            }, // when multiple args, return first arg
            new object[]
            {
                new string[] { }, "  |UserInputAfterWhitespace", "UserInputAfterWhitespace"
            }, // when no args and whitespace console input, ask again and return valid input
            new object[]
            {
                new string[] { }, "  |User Input With Spaces", "User Input With Spaces"
            }, // when no args, handle whitespace then return console input with space
            new object[]
            {
                new string[] { "FirstArg", " " }, "", "FirstArg"
            }, // when multiple args present but second arg empty, return first arg
            new object[]
            {
                new string[] { }, "|  |UserInputAfterEmptyAndWhitespace", "UserInputAfterEmptyAndWhitespace"
            }, // when no args and multiple invalid console inputs, ask again and return valid input
        };
    }


    public void Dispose()
    {
        _output = null;
        _consoleInputMock = null;
    }
}