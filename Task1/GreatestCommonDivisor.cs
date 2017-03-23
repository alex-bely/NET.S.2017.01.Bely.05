﻿using System;
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
        /// <param name="numbers">Source array of numbers</param>
        /// <returns>The GCD of received values</returns>
        /// <exception cref="ArgumentException">Source array contains less than 2 elements or all the elements are zeros</exception>
        /// <exception cref="ArgumentNullException">Source array is null referenced</exception>
        public static int ClassicGCD(params int[] numbers)
        {
            
            if (numbers == null) throw new ArgumentNullException();
            if (numbers.Length < 2) throw new ArgumentException();
            var watch = Stopwatch.StartNew();
            int GCD= numbers.Select(x => Math.Abs(x)).OrderByDescending(c => c).Aggregate(GCD_Euclid);
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            //Debug.WriteLine(elapsedMs);
            Console.WriteLine(elapsedMs);  //There are some troubles with NUnit3 adapter and Debug.WriteLine 
                                           //that's why Console.WriteLine is used for test output.
            
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
            var watch = Stopwatch.StartNew();
            int GCD = numbers.Select(x => Math.Abs(x)).OrderByDescending(c => c).Aggregate(GCD_Bin);
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            //Debug.WriteLine(elapsedMs);
            Console.WriteLine(elapsedMs);  //There are some troubles with NUnit3 adapter and Debug.WriteLine 
                                           //that's why Console.WriteLine is used for test output.
            return GCD;
        }
        #endregion




        #region Private members
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
        #endregion
    }
}
