namespace Palindrome_Partitioner
{
    internal class Program
    {
        /*Please spend no more than 2-3 hours creating the following C# .NET 6 or a Javascript solution to
         calculate palindrome partitions consisting of a .net core command-line application that takes a single string 
         as an argument then writes to the command line all possible palindrome partitioning, e.g. "aab" would return 
         aa,b and a,a,b and "geeks" would return g,e,e,k,s and g,ee,k,s.*/
        private static int Main(string[] args)
        {
            // to meet requirement:
            // command-line application that takes a single string as an argument
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of arguments");
                return -1;
            }


            return 0;
        }
    }
}