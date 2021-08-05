using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalc
    {
        public int Result { get; set; }

        public int Add(string numbers)
        {
            if (numbers.Contains('-'))
            {
                Regex regex = new Regex(@"(-\d*)");
                string[] negativeNumbers = FindRegex(regex, numbers);
                string message = "Negatives not allowed: ";
                foreach (string number in negativeNumbers)
                {
                    message += "[" + number + "] ";
                }
                throw new Exception(message);
            }

            if (numbers == "")
                return 0;

            if (numbers.Length == 1)
                return int.Parse(numbers);

            if (numbers.StartsWith('/'))
            {
                Regex regex = new Regex(@"[[/]*(.*?)[]\n]");
                string[] delimiters = FindRegex(regex, numbers);
                string[] numbersArr = numbers.Split("\n", StringSplitOptions.None)[1]
                                             .Split(delimiters, StringSplitOptions.None);
                return Sum(numbersArr);
            }

            if (numbers.Contains("\n") || numbers.Contains(","))
            {
                string[] delimeters = new[] { "\n", "," };
                string[] numbersArr = numbers.Split(delimeters, StringSplitOptions.None);
                return Sum(numbersArr);
            }
            throw new ArgumentException("Incorrect values entered!");

        }
        public string[] FindRegex(Regex regex, string numbers)
        {
            Match match = regex.Match(numbers);
            List<string> matchesList = new List<string>();
            while (match.Success)
            {
                matchesList.Add(match.Groups[1].ToString());
                match = match.NextMatch();
            }
            string[] matches = matchesList.ToArray();
            return matches;
        }
        public int Sum(string[] numbersArr)
        {
            foreach (string number in numbersArr)
            {
                if (int.Parse(number) < 1000)
                    Result += int.Parse(number);
            }
            return Result;
        }
        static void Main()
        {
        }
    }
}
