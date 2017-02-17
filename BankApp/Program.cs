using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public static class Bank
    {
        public static bool NumCheck(this string cardNumber)
        {
            return NumCheck(cardNumber.Select(c => c - '0').ToArray());
        }
        private static bool NumCheck(this int[] digits)
        {
            return GetCheckValue(digits) == 0;
        }
        private static int GetCheckValue(int[] digits)
        {
            return digits.Select((d, i) => i % 2 == digits.Length % 2 ? ((2 * d) % 10) + d / 5 : d).Sum() % 10;
        }
    }
    class Program
    {

        
        
        static void Main(string[] args)
        {
            long[] testNumbers = {49927398716, 49927398717, 1234567812345678, 1234567812345670};
            foreach (var testNumber in testNumbers)
                Console.WriteLine("{0} Is {1}a valid Credit Card Number", testNumber, testNumber.ToString().NumCheck() ? "" : "Not ");
            Console.ReadKey();
        }
    }
}
