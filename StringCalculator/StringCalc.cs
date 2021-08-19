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
                string[] negativeNumbers = FindNegativeNumbers(numbers);
                ShowNegativeNumbers(negativeNumbers);
            }

            if (numbers == "")
                return 0;

            if (numbers.Length == 1)
                return int.Parse(numbers);

            if (numbers.StartsWith('/'))
            {
                string[] delimiters = FindDelimiters(numbers);
                string numbersPart = numbers.Split("\n", StringSplitOptions.None)[1];
                string[] numbersArr = GetNumbers(numbersPart, delimiters);
                return Sum(numbersArr);
            }

            if (numbers.Contains("\n") || numbers.Contains(","))
            {
                string[] delimiters = new[] { "\n", "," };
                string[] numbersArr = GetNumbers(numbers, delimiters);
                return Sum(numbersArr);
            }
            throw new ArgumentException("Incorrect values entered!");

        }

        private string[] GetNumbers(string numbers, string[] delimiters)
        {
            return numbers.Split(delimiters, StringSplitOptions.None);
        }

        private string[] FindDelimiters(string numbers)
        {
            // Find delimiters between "[" and "]" or between "//" and "\n"
            Regex regex = new Regex(@"[[/]*(.*?)[]\n]");
            return FindRegex(regex, numbers);
        }

        private string[] FindNegativeNumbers(string numbers)
        {
            Regex regex = new Regex(@"(-\d*)");
            return FindRegex(regex, numbers);
        }
        private void ShowNegativeNumbers(string[] negativeNumbers)
        {
            string message = "Negatives not allowed: ";
            foreach (string number in negativeNumbers)
            {
                message += "[" + number + "] ";
            }
            throw new Exception(message);
        }
        private string[] FindRegex(Regex regex, string numbers)
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
        private int Sum(string[] numbersArr)
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
