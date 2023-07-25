namespace Palindrome_Partitioner
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var inputHandler = new InputHandler(args, new ConsoleInput());
            var input = inputHandler.GetUserInput();

            var partitioner = new Partitioner();

            // for accurate comparisons
            // we could also filter white space, or split the string. not sure if this is a necessary requirement.
            input = input.ToLower();
            var partitions = partitioner.Partition(input);

            foreach (List<string> partition in partitions)
            {
                Console.WriteLine($"[{string.Join(", ", partition)}]");
            }
        }
    }
}