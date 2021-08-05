﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalc
    {
        public int Sum { get; set; }
        public string Message { get; set; }
        public int Add(string numbers)
        {
            if (numbers.Contains('-'))
            {
                Regex regex = new Regex(@"-\d*");
                MatchCollection matches = regex.Matches(numbers);
                Message = "Negatives not allowed: ";
                foreach (Match match in matches)
                {
                    Message += "[" + match.Value + "] ";
                }
                throw new Exception(Message);
            }

            if (numbers == "")
                return 0;

            if (numbers.Length == 1)
                return int.Parse(numbers);

            if (numbers.StartsWith('/') && numbers.Contains('[') && numbers.Contains(']'))
            {
                Regex regex = new Regex(@"\[(.*?)\]");
                Match match = regex.Match(numbers);
                List<string> delimitersList = new List<string>();
                while (match.Success)
                {
                    delimitersList.Add(match.Groups[1].ToString());
                    match = match.NextMatch();
                }
                string[] delimiters = delimitersList.ToArray();

                string[] inputArr = numbers.Split("\n", StringSplitOptions.None);
                string[] numArr = inputArr[1].Split(delimiters, StringSplitOptions.None);
                foreach (string number in numArr)
                {
                    if (int.Parse(number) < 1000)
                        Sum += int.Parse(number);
                }
                return Sum;
            } 

            if (numbers.StartsWith('/'))
            {
                string[] inputArr = numbers.Split(new string[] { "\n" }, StringSplitOptions.None);

                char delimiter = Convert.ToChar(inputArr[0].TrimStart('/'));
                string[] numArr = inputArr[1].Split(delimiter);

                foreach (string number in numArr)
                {
                    if (int.Parse(number) < 1000)
                        Sum += int.Parse(number);
                }
                return Sum;
            }

            string[] delimeters = new[] { "\n", "," };
            string[] numbersArr = numbers.Split(delimeters, StringSplitOptions.None);

            foreach (string number in numbersArr)
            {
                if (int.Parse(number) < 1000)
                    Sum += int.Parse(number);
            }
            return Sum;
        }
        static void Main()
        {
        }

    }
}
