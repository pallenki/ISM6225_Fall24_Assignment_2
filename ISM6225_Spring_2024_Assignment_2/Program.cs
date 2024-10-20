using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                HashSet<int> numSet = new HashSet<int>(nums);
                List<int> missingNumbers = new List<int>();

                // Check for numbers from 1 to n
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!numSet.Contains(i))
                    {
                        missingNumbers.Add(i);
                    }
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                List<int> evenNums = new List<int>();
                List<int> oddNums = new List<int>();
    
                // Separate even and odd numbers
                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                    {
                        evenNums.Add(num);
                    }
                    else
                    {
                        oddNums.Add(num);
                    }
                }
    
                // Combine even and odd numbers
                evenNums.AddRange(oddNums);
    
                return evenNums.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    // Check if the two numbers add up to the target
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j }; // Return the indices
                    }
                }
            }

                // Return an empty array if no solution is found
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Initialize the variables to track the largest and smallest numbers
            int[] max = { int.MinValue, int.MinValue, int.MinValue }; // For the largest three
            int[] min = { int.MaxValue, int.MaxValue };             // For the smallest two

            // Traverse the array to find the required values
            foreach (int num in nums)
            {
                // Update the largest three
                if (num > max[0])
                {
                    max[2] = max[1];
                    max[1] = max[0];
                    max[0] = num;
                }
                else if (num > max[1])
                {
                    max[2] = max[1];
                    max[1] = num;
                }
                else if (num > max[2])
                {
                    max[2] = num;
                }

                // Update the smallest two
                if (num < min[0])
                {
                    min[1] = min[0];
                    min[0] = num;
                }
                else if (num < min[1])
                {
                    min[1] = num;
                }
            }

                // Calculate the maximum product of three numbers
                int product1 = max[0] * max[1] * max[2]; // Product of the three largest numbers
                int product2 = min[0] * min[1] * max[0];  // Product of the two smallest and the largest

                return Math.Max(product1, product2); // Return the maximum of the two products
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // built-in Convert.ToString to convert to binary
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                 // Start with the first element as the minimum
                int minimum = nums[0];

                // Iterate through the array to find the minimum
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] < minimum)
                    {
                        minimum = nums[i]; // Update minimum if a smaller element is found
                    }
                }

                return minimum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindromes
                if (x < 0)
                {
                    return false;
                }

                // Numbers that end with 0 (except for 0 itself) are not palindromes
                if (x % 10 == 0 && x != 0)
                {
                    return false;
                }

                int rev = 0;
                int org = x;

                while (x > 0)
                {
                    int digit = x % 10; // Get the last digit
                    rev = rev * 10 + digit; // Append digit to reversed number
                    x /= 10; // Remove the last digit from x
                }

                // Check if the original number is equal to the reversed number
                return org == rev;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException("n must be non-negative.");
                }
                
                if (n == 0) return 0;
                if (n == 1) return 1;

                int a = 0; 
                int b = 1;
                int fib = 0; 

                for (int i = 2; i <= n; i++)
                {
                    fib = a + b; 
                    a = b; 
                    b = fib; 
                }
                
                return fib; 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
