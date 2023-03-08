using System;
using System.Collections.Generic;
using System.Linq;

namespace DecryptNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cryptedNumbers = new List<string>
            {
                "())(",
                "*$(#&",
                "!!!!!!!!!!",
                "$*^&@!",
                "!)(^&(#@",
                "!)(#&%(*@#%"
            };

            var newStr = new List<string>();

            foreach (var word in cryptedNumbers)
            {
                var word1 = word.Select(s => (
                    s == '!' ? '1' :
                    s == '@' ? '2' :
                    s == '#' ? '3' :
                    s == '$' ? '4' :
                    s == '%' ? '5' :
                    s == '^' ? '6' :
                    s == '&' ? '7' :
                    s == '*' ? '8' :
                    s == '(' ? '9' :
                    s == ')' ? '0' : s)).ToList();

                newStr.Add(new string(word1.ToArray()));
            }

            Console.WriteLine(string.Join(" ", newStr));
        }
    }
}