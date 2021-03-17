using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunnyCalculator
{
    public class Calculator
    {
        public int? Add(string numbers)
        {
            try
            {
                if (string.IsNullOrEmpty(numbers))
                    return 0;

                HandleStringFormatValidity(numbers);

                var collectionOfNumbers = ExpandToNumbers(numbers);
                var negativeNumbers = NegativeNumbersThatExists(collectionOfNumbers);

                CheckForNegativeNumbers(negativeNumbers);

                return collectionOfNumbers.Sum();
            }
            catch (IllegalFormatException ex)
            {
                Console.WriteLine($":-( You have been very naughty: {ex.Message}. The allowed Formats are any of the following: \n\n //[delimiter]\\n[numbers…] \n\n or \n \n 1\\n2,3 \n\n or \n\n simply 1,2");
            }
            catch (NegativesNotAllowedException ex)
            {
                Console.WriteLine($@":-( You have been very naughty: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($@":-( Excuse me!!. Great things fail atimes: {ex.Message}");
            }
            return null;
        }
        /// <summary>
        /// Check for Negative Numbers
        /// </summary>
        /// <param name="negativeNumbers"></param>
        private void CheckForNegativeNumbers(List<int> negativeNumbers)
        {
            if (negativeNumbers.Count() > 0)
                throw new NegativesNotAllowedException($@"Negative Numbers: ({string.Join(",", negativeNumbers).TrimEnd()}) are not allowed");
        }
        /// <summary>
        /// Handle string format checks
        /// </summary>
        /// <param name="numbers"></param>
        private void HandleStringFormatValidity(string numbers)
        {
            if (!StringFormatIsValid(numbers))
                throw new IllegalFormatException($@"Illegal Format");
        }
        /// <summary>
        /// Check to see if the format is according to be specification
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private bool StringFormatIsValid(string numbers)
        {
            switch (numbers)
            {
                case string n when n.EndsWith(@"\n"):
                    return false;
                case string n when n.ToCharArray().ToList().Any(c => char.IsDigit(c)) == false:
                    return false;
                default:
                    return true;
            }
        }
        private List<string> CheckDelimeters(string numbers)
        {
            switch (numbers)
            {
                case string n when n.StartsWith("//") == false && n.Contains(@"\n") == false:
                    return n.Split(",").ToList();
                case string n when n.StartsWith("//") == false && n.Contains(@"\n"):
                    return n.Replace(@"\n", ",").Split(",").ToList();
                case string n when n.StartsWith("//") && n.Contains(@"\n") == false:
                    return n.TrimStart(n.ToCharArray()[2]).Substring(3).Trim().Split(n.ToCharArray()[2]).ToList();
                case string n when n.StartsWith("//") && n.Contains(@"\n"):
                    return n.TrimStart(n.ToCharArray()[2]).Substring(3).Replace(@"\n", string.Empty).Trim().Split(n.ToCharArray()[2]).ToList();
                default:
                    return new List<string>();
            }
        }
        /// <summary>
        /// Expands the operands into a collection of integers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private List<int> ExpandToNumbers(string numbers)
        {
            return CheckDelimeters(numbers).Select(c => int.Parse(c)).ToList();
        }
        /// <summary>
        /// Checks to see if negative numbers exist in the collection
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private List<int> NegativeNumbersThatExists(List<int> numbers)
        {
            return numbers.Where(n => n < 0).ToList();
        }
    }
}
