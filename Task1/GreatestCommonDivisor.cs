using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1
{ 
        /// <summary>
        /// Provides methods for calculating GCD
        /// </summary>
    public static class GreatestCommonDivisor
    {

        #region Public members

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Euclid algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>The GCD of received values</returns>
        public static int ClassicGCD(int number1, int number2)
        {
            int GCD = CommonGCD(Math.Abs(number1), Math.Abs(number2), GCD_Euclid);
            return GCD;
        }


        /// <summary>
        /// Returns the GCD of more than one number, calculated with Euclid algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="milliseconds">Variable for ellapsed time</param>
        /// <returns>The GCD of received values</returns>
        public static int ClassicGCD(int number1, int number2, out double milliseconds)
        {
            var watch = Stopwatch.StartNew();
            int GCD = CommonGCD(Math.Abs(number1), Math.Abs(number2), GCD_Euclid);
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            milliseconds = elapsedMs;
            return GCD;
        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Euclid algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="number3">Third number</param>
        /// <returns>The GCD of received values</returns>
        public static int ClassicGCD(int number1, int number2, int number3)
        {
            if (number3 == 0) Swap(ref number1, ref number3);
            int GCD = CommonGCD(Math.Abs(number1), Math.Abs(number2), Math.Abs(number3),GCD_Euclid);
            return GCD;
        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Euclid algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="number3">Third number</param>
        /// <param name="milliseconds">Variable for ellapsed time</param>
        /// <returns>The GCD of received values</returns>
        public static int ClassicGCD(int number1, int number2, int number3, out double milliseconds)
        {
            var watch = Stopwatch.StartNew();
            if (number3 == 0) Swap(ref number1, ref number3);
            int GCD = CommonGCD(Math.Abs(number1), Math.Abs(number2), Math.Abs(number3), GCD_Euclid);
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            milliseconds = elapsedMs;
            return GCD;
        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Euclid algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="numbers">Source array of numbers</param>
        /// <returns>The GCD of received values</returns>
        /// <exception cref="ArgumentException">Source array contains less than 2 elements or all the elements are zeros</exception>
        /// <exception cref="ArgumentNullException">Source array is null referenced</exception>
        public static int ClassicGCD(params int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException();
            if (numbers.Length < 4) throw new ArgumentException();
            int GCD=CommonGCD(GCD_Euclid,numbers);
            return GCD;
            
        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Euclid algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="numbers">Source array of numbers</param>
        /// <param name="milliseconds">Variable for ellapsed time</param>
        /// <returns>The GCD of received values</returns>
        /// <exception cref="ArgumentException">Source array contains less than 2 elements or all the elements are zeros</exception>
        /// <exception cref="ArgumentNullException">Source array is null referenced</exception>
        public static int ClassicGCD(out double milliseconds, params int[] numbers)
        {
            var watch = Stopwatch.StartNew();
            if (numbers == null) throw new ArgumentNullException();
            if (numbers.Length < 2) throw new ArgumentException();
            int GCD = CommonGCD(GCD_Euclid, numbers);
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            milliseconds = elapsedMs;
            return GCD;
        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Binary algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>The GCD of received values</returns>
        public static int BinaryGCD(int number1, int number2)
        {
            int GCD = CommonGCD(Math.Abs(number1), Math.Abs(number2), GCD_Bin);
            return GCD;
        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Binary algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="milliseconds">Variable for ellapsed time</param>
        /// <returns>The GCD of received values</returns>
        public static int BinaryGCD(int number1, int number2, out double milliseconds)
        {
            var watch = Stopwatch.StartNew();
            int GCD = CommonGCD(Math.Abs(number1), Math.Abs(number2), GCD_Bin);
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            milliseconds = elapsedMs;
            return GCD;
        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Binary algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="number3">Third number</param>
        /// <returns>The GCD of received values</returns>
        public static int BinaryGCD(int number1, int number2, int number3)
        {
            if (number3 == 0) Swap(ref number1, ref number3);
            int GCD = CommonGCD(Math.Abs(number1), Math.Abs(number2), Math.Abs(number3), GCD_Bin);
            return GCD;
        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Binary algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="number3">Third number</param>
        /// <param name="milliseconds">Variable for ellapsed time</param>
        /// <returns>The GCD of received values</returns>
        public static int BinaryGCD(int number1, int number2, int number3, out double milliseconds)
        {
            var watch = Stopwatch.StartNew();
            if (number3 == 0) Swap(ref number1, ref number3);
            int GCD = CommonGCD(Math.Abs(number1), Math.Abs(number2), Math.Abs(number3), GCD_Bin);
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            milliseconds = elapsedMs;
            return GCD;
        }





        /// <summary>
        /// Returns the GCD of more than one number, calculated with Binary algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="numbers">Source array of numbers</param>
        /// <returns>The GCD of received values</returns>
        /// <exception cref="ArgumentException">Source array contains less than 2 elements or all the elements are zeros</exception>
        /// <exception cref="ArgumentNullException">Source array is null referenced</exception>
        public static int BinaryGCD(params int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException();
            if (numbers.Length < 2) throw new ArgumentException();
            int GCD = CommonGCD(GCD_Bin, numbers);
            return GCD;

        }

        /// <summary>
        /// Returns the GCD of more than one number, calculated with Binary algorithm.
        /// Also calculates ellapsed time in milliseconds
        /// </summary>
        /// <param name="numbers">Source array of numbers</param>
        /// <param name="milliseconds">Variable for ellapsed time</param>
        /// <returns>The GCD of received values</returns>
        /// <exception cref="ArgumentException">Source array contains less than 2 elements or all the elements are zeros</exception>
        /// <exception cref="ArgumentNullException">Source array is null referenced</exception>
        public static int BinaryGCD(out double milliseconds, params int[] numbers)
        {
            var watch = Stopwatch.StartNew();
            if (numbers == null) throw new ArgumentNullException();
            if (numbers.Length < 4) throw new ArgumentException();
            int GCD = CommonGCD(GCD_Bin, numbers);
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            milliseconds = elapsedMs;
            return GCD;
        }
        #endregion




        #region Private members

        /// <summary>
        /// Returns the GCD of two numbers, calculated with specified algorithm
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="GCD_Algorithm">Type of algorithm</param>
        /// <returns>The GCD of received values</returns>
        private static int CommonGCD(int number1, int number2, Func<int, int, int>GCD_Algorithm)
        {
            return GCD_Algorithm(number1, number2);
        }

        /// <summary>
        /// Returns the GCD of three numbers, calculated with specified algorithm
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">>Second number</param>
        /// <param name="number3">Third number</param>
        /// <param name="GCD_Algorithm">Type of algorithm</param>
        /// <returns>The GCD of received values</returns>
        private static int CommonGCD(int number1, int number2, int number3, Func<int, int, int> GCD_Algorithm)
        {
            return GCD_Algorithm(number1, GCD_Algorithm(number2, number3));
        }

        /// <summary>
        /// Returns the GCD of numbers, calculated with specified algorithm
        /// </summary>
        /// <param name="GCD_Algorithm">Type of algorithm</param>
        /// <param name="numbers">Set of numbers</param>
        /// <returns>The GCD of received values</returns>
        private static int CommonGCD(Func<int, int, int> GCD_Algorithm, params int[] numbers)
        {
            return numbers.Select(x => Math.Abs(x)).OrderByDescending(c => c).Aggregate(GCD_Algorithm);
        }

        /// <summary>
        /// Returns the GCD of two elements, calculated with Euclid algorithm
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>The GCD of received numbers</returns>
        /// <exception cref="ArgumentException">Both elements are zeros</exception>
        private static int GCD_Euclid(int number1, int number2)
        {
            if (number1 == 0 && number2 == 0) throw new ArgumentException();
            else if (number1 == 0) return number2;
            else if (number2 == 0) return number1;
            while (number1 != number2)
            {
                if (number1 > number2)
                {
                    number1 = number1 - number2;
                }
                else
                {
                    number2 = number2 - number1;
                }
            }
            return number1;
        }


        /// <summary>
        /// Returns the GCD of two elements, calculated with Binary algorithm
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <returns>The GCD of received numbers</returns>
        /// <exception cref="ArgumentException">Both elements are zeros</exception>
        private static int GCD_Bin(int number1, int number2)
        {
            if (number1 == 0 && number2 == 0) throw new ArgumentException();
            if (number1 == 0) return number2;
            if (number2 == 0) return number1;
            if (number1 == number2) return number1;
            if (number1 == 1 || number2 == 1) return 1;
            if ((number1 % 2 == 0) && (number2 % 2 == 0)) return 2 * GCD_Bin(number1 / 2, number2 / 2);
            if ((number1 % 2 == 0) && (number2 % 2 != 0)) return GCD_Bin(number1 / 2, number2);
            if ((number1 % 2 != 0) && (number2 % 2 == 0)) return GCD_Bin(number1, number2 / 2);
            if (number1 > number2) return GCD_Bin((number1 - number2) / 2, number2);
            else return GCD_Bin(number1, (number2 - number1) / 2);

        }

        /// <summary>
        /// Swaps two int variables
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        private static void Swap(ref int number1, ref int number2)
        {
            int temp = number2;
            number2 = number1;
            number1 = temp;
        }


        #endregion
    }
}
