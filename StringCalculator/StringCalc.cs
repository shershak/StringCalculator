using System;

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

            string[] delimeters = new[] { "," };
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
