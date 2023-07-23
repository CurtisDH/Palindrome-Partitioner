namespace Palindrome_Partitioner;

public class Partitioner
{
    private PalindromeChecker _checker;

    public Partitioner()
    {
        _checker = new PalindromeChecker();
    }

    public List<List<string>> Partition(string s)
    {
        List<List<string>> result = new List<List<string>>();
        PartitionRecursion(result, new List<string>(), s, 0);
        return result;
    }

    private void PartitionRecursion(List<List<string>> result, List<string> tempList, string s, int start)
    {
        if (start == s.Length)
        {
            result.Add(new List<string>(tempList));
        }
        else
        {
            for (int i = start; i < s.Length; i++)
            {
                if (_checker.IsPalindrome(s, start, i))
                {
                    tempList.Add(s.Substring(start, i + 1 - start));
                    PartitionRecursion(result, tempList, s, i + 1);
                    tempList.RemoveAt(tempList.Count - 1); // backtrack
                }
            }
        }
    }
}