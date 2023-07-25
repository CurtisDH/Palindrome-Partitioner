# Palindrome Partitioner

This project implements a C# .NET 6 command-line application as a solution to the palindrome partitioning problem. The program takes a single string as an argument and outputs all possible palindrome partitioning.

## About the Project

Given a string, the task is to output all possible partitions such that every partitioned substring is a palindrome. A palindrome in this instance is defined as a word, phrase, number, or other sequence of characters that reads the same forward and backward, ignoring capitalisation.

Examples:<br/>

- For the string "aab", the output would be: <br/>
[a, a, b]<br/>
[aa, b]<br/>

- For the string "geeks", the output would be: <br/>
[g, e, e, k, s]<br/>
[g, ee, k, s]<br/>
- For the string "racecar", the output would be:<br/>
[r, a, c, e, c, a, r]<br/>
[r, a, cec, a, r]<br/>
[r, aceca, r]<br/>
[racecar]<br/>
<br/>
The project is developed as a simple command-line application. You can input the string directly through the command-line arguments, or run it and enter your desired string through the internal prompts, the results will be displayed in the command-line interface.

## Running the Application

To run the application, simply navigate to the project directory in your command-line interface and run the following command:

<em>dotnet run <your_string> </em><br/>
or alternatively just <br/>
<em>dotnet run </em><br/>
which will prompt you to enter your string

Replace `<your_string>` with the string you want to partition.

## Running the Tests

The project includes a suite of unit tests to validate the correctness of the palindrome partitioner. These tests utilise the mocking framework **Moq** and the unit testing framework: **Xunit**. To run the tests, navigate to the test project directory in your command line and run the following command:

dotnet test


## Algorithm Choice

The solution for this problem is a recursive Depth-First Search (DFS) aided by the Two-Pointer technique. Here is a brief explanation of the motivation behind these choices:

### Depth-First Search (DFS)

We need to explore *all possible partitions* of the string, which leads to a tree-like structure of decisions, where each node represents a partitioning choice. DFS is well suited for this task as it explores as far as possible along each branch before backtracking. 

In our recursive DFS (`PartitionRecursion` method), we make a decision at each character in the string: should we partition here or not? If the substring up to the current character is a palindrome, we partition and recurse on the remaining string.

This DFS algorithm exhaustively searches all possibilities to generate all palindrome partitions, and is typically regarded as the standard solution for this type of problem.

It is worth making a note of the fact that this algorithm has a worst case time complexity of **O(n!)**

### Two-Pointer Technique

The Two-Pointer technique is used to efficiently check if a substring is a palindrome. This algorithm improves the efficiency of our solution by reducing unnecessary checks.

In the `PalindromeChecker` class (`IsPalindrome` method), we start with two pointers at the ends of the substring and move them towards the center, comparing the characters at each step. If the characters do not match, we know the substring is not a palindrome. If we make it to the middle without finding a mismatch, the substring is a palindrome.

This Two-Pointer check is **O(n)**, reducing the time complexity of the palindrome check and making our overall solution more efficient.


### Other considered algorithms and why they were not selected
#### Dynamic Programming
While DP is a powerful method for solving problems with overlapping subproblems and optimal substructure, it doesn't quite fit our needs here. DP would be a great fit for a problem where we needed to find the minimum number of partitions to make all substrings palindromes. However, we need all possible partitions in this problem, which makes DFS a more suitable approach.
#### Breadth-First Search (BFS)
BFS is another traversal method that could be used. But for our use case, it doesn't offer any clear advantages over DFS. Additionally, DFS is better suited for generating all possible solutions because it naturally explores all possibilities via backtracking.
#### Iterative Approach
An iterative solution could be used, but it doesn't offer any significant advantages over DFS, and the resulting code can become quite complex leading to it becoming more difficult to maintain and read when dealing with this type of problem. 

## Resources

https://en.wikipedia.org/wiki/Dynamic_programming<br/>
https://www.geeksforgeeks.org/breadth-first-search-or-bfs-for-a-graph/<br/>
https://www.geeksforgeeks.org/depth-first-search-or-dfs-for-a-graph/<br/>


https://www.geeksforgeeks.org/palindrome-partitioning-dp-17/<br/>
https://leetcode.com/problems/palindrome-partitioning/solutions/3083545/backtracking-implementation-using-c/<br/>

