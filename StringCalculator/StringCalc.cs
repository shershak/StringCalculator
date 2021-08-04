﻿using System;

namespace StringCalculator
{
    public class StringCalc
    {
        public int Sum { get; set; }
        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;

            if (numbers.Length == 1)
                return int.Parse(numbers);

            if (numbers.StartsWith('/'))
            {
                string[] inputArr = numbers.Split(new string[] { "\n" }, StringSplitOptions.None);

                char delimiter = Convert.ToChar(inputArr[0].TrimStart('/'));
                string[] numArr = inputArr[1].Split(delimiter);

                foreach (string number in numArr)
                {
                    Sum += int.Parse(number);
                }
                return Sum;
            }

            string[] delimeters = new[] { "\n", "," };
            string[] numbersArr = numbers.Split(delimeters, StringSplitOptions.None);
            foreach (string number in numbersArr)
            {
                Sum += int.Parse(number);
            }
            return Sum;
        }
        static void Main()
        {  
        }
    }
}