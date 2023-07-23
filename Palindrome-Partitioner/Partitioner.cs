namespace Palindrome_Partitioner;

public class Partitioner
{
    private PalindromeChecker _checker;

    public Partitioner()
    {
        _checker = new PalindromeChecker();
    }

    public List<List<string>> Partition(string input)
    {
        List<List<string>> result = new List<List<string>>();
        PartitionRecursion(result, new List<string>(), input, 0);
        return result;
    }

    private void PartitionRecursion(List<List<string>> result, List<string> tempList, string input, int start)
    {
        if (start == input.Length)
        {
            result.Add(new List<string>(tempList));
        }
        else
        {
            for (int i = start; i < input.Length; i++)
            {
                if (_checker.IsPalindrome(input, start, i))
                {
                    tempList.Add(input.Substring(start, i + 1 - start));
                    PartitionRecursion(result, tempList, input, i + 1);
                    tempList.RemoveAt(tempList.Count - 1); // backtrack
                }
            }
        }
    }
}