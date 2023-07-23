namespace Palindrome_Partitioner;

public class PalindromeChecker
{
    public bool IsPalindrome(string input, int low, int high)
    {
        while (low < high)
        {
            // two-pointer algorithm -- O(n)
            if (input[low++] != input[high--])
            {
                return false;
            }
        }

        return true;
    }
}