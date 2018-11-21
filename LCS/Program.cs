using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace LongestCommonSubsequence
{
    public class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("Please input the first string: ");
                var str = Console.ReadLine();
                Console.Write("Please input the second string: ");
                var str2 = Console.ReadLine();
                Console.WriteLine("Result: " + LCS(str, str2) +"\n");
            }


        }


        public static string LCS(string a, string b)
        {
            var resultStack = new Stack();
            var charA = a.ToArray();
            var charB = b.ToArray();

            var C = new int[a.Length + 1, b.Length + 1];    //use an array to sdore length of sub common strings

            // row 0 and column 0 are initialized to 0 
            for (var i = 0; i < a.Length; i++) C[i, 0] = 0;
            for (var j = 0; j < b.Length; j++) C[0, j] = 0;

            for (var i = 0; i < a.Length; i++)
            {
                for (var j = 0; j < b.Length; j++)
                {
                    C[i + 1, j + 1] = charA[i] == charB[j] ? C[i, j] + 1 : Math.Max(C[i + 1, j], C[i, j + 1]);   // Dynamic Programming
                }
            }

            // read the substring out from the matrix
            for (int x = a.Length, y = b.Length; x != 0 && y != 0;)
            {
                if (C[x, y] == C[x - 1, y])
                { x--; }
                else if (C[x, y] == C[x, y - 1])
                { y--; }
                else
                {
                    if (charA[x - 1] == charB[y - 1])
                        resultStack.Push(charA[x - 1]);
                    x--;
                    y--;
                }
            }
            //reverse string order
            var sb = new StringBuilder();
            while (resultStack.Count > 0)
            {
                sb.Append(resultStack.Pop());
            }
            return sb.ToString();
        }

    }
}
