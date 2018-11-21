using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Pro3_JingGuo.CorrectnessTests
{
    [TestClass()]
    public class ProgramCorrectnessTests
    {
        [TestMethod()]
        public void CorrectnessTests()
        {
            string sequence1 = LongestCommonSubsequence.Program.LCS("cjdkslds", "odslups");
            Assert.AreEqual("dsls", sequence1);


            string sequence2 = LongestCommonSubsequence.Program.LCS("ast93j4ncowsjfalejafk", "0jtnsdkfjjqiudfuafksj");
            Assert.AreEqual("tnsjfafk", sequence2);
        }
    }
}


namespace Pro3_JingGuo.RuntimeTests
{
    [TestClass()]
    public class ProgramCorrectnessTests
    {
        [TestMethod()]
        public void LCSRuntimeTests()
        {
            // test data string length
            var testStringLength = new int[] { 10, 100, 1000, 10000};
            foreach (var i in testStringLength)
            {
                GC.Collect();   //collect memory
                GC.WaitForPendingFinalizers();
                var t1 = GenerateRandomNumber(i);
                var t2 = GenerateRandomNumber(i);
                Stopwatch sw = Stopwatch.StartNew();
                string sequence1 = LongestCommonSubsequence.Program.LCS(t1, t2);
                sw.Stop();
                Console.WriteLine("testStringLength:" + i + "   Time:" + sw.Elapsed.TotalSeconds);
            }
        }

        private static char[] constant =
        {
        '0','1','2','3','4','5','6','7','8','9',
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };
        public static string GenerateRandomNumber(int Length)
        {
            var newRandom = new System.Text.StringBuilder(62);
            var rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
    }
}
