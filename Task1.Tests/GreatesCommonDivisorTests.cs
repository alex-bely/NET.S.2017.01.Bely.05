﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;
using System.Diagnostics;

namespace Task1.Tests
{
    [TestFixture]
    public class GreatesCommonDivisorTests
    {
        #region ClassicGDC

        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(0, 100, ExpectedResult = 100)]
        [TestCase(0, -1, ExpectedResult = 1)]
        [TestCase(0, -10, ExpectedResult = 10)]
        [TestCase(-15, 55, ExpectedResult = 5)]
        [TestCase(-6, -9, ExpectedResult = 3)]
        [TestCase(13, 27, ExpectedResult = 1)]
        [TestCase(5, 5, ExpectedResult = 5)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, 1,  ExpectedResult = 1)]
        public int ClassicGCD_TwoIntegerNumbers_PositiveTest(int number1, int number2)
        {
            return GreatestCommonDivisor.ClassicGCD(number1, number2);
        }


        [TestCase(0, 1, 0d,ExpectedResult = 1)]
        [TestCase(0, 100, 0d, ExpectedResult = 100)]
        [TestCase(0, -1, 0d, ExpectedResult = 1)]
        [TestCase(0, -10, 0d, ExpectedResult = 10)]
        [TestCase(-15, 55, 0d, ExpectedResult = 5)]
        [TestCase(-6, -9, 0d, ExpectedResult = 3)]
        [TestCase(13, 27, 0d, ExpectedResult = 1)]
        [TestCase(5, 5, 0d, ExpectedResult = 5)]
        [TestCase(int.MaxValue, int.MaxValue, 0d, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, 1, 0d, ExpectedResult = 1)]
        public int ClassicGCD_TwoIntegerNumbers_PositiveTest(int number1, int number2, out double time)
        {
            return GreatestCommonDivisor.ClassicGCD(number1, number2, out time);
        }

        [TestCase(0, 0, 1, ExpectedResult = 1)]
        [TestCase(0, 1, 0, ExpectedResult = 1)]
        [TestCase(1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 100, ExpectedResult = 100)]
        [TestCase(-1, 0, 0, ExpectedResult = 1)]
        [TestCase(-10, 0, 0, ExpectedResult = 10)]
        [TestCase(-15, 10, 55, ExpectedResult = 5)]
        [TestCase(-15, 10, -15, ExpectedResult = 5)]
        [TestCase(-6, -18, -9, ExpectedResult = 3)]
        [TestCase(13, 15, 27, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, 1, int.MaxValue, ExpectedResult = 1)]
        public int ClassicGCD_ThreeIntegerNumbers_PositiveTest(int number1, int number2,int number3)
        {
            return GreatestCommonDivisor.ClassicGCD(number1, number2, number3);

        }

        [TestCase(0, 0, 0, 0, 1, ExpectedResult = 1)]
        [TestCase(0, 0, 0, 0, 100, ExpectedResult = 100)]
        [TestCase(0, 0, 0, 0, -1, ExpectedResult = 1)]
        [TestCase(0, 0, 0, 0, -10, ExpectedResult = 10)]
        [TestCase(-15, 5, 10, 55, 125, ExpectedResult = 5)]
        [TestCase(-6, -18, -3, -9, ExpectedResult = 3)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, 1, int.MaxValue, int.MaxValue, ExpectedResult = 1)]

        public int ClassicGCD_MoreThanThreeIntegerNumbers_PositiveTest(params int[] numbers)
        {

            return GreatestCommonDivisor.ClassicGCD(numbers);

        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 0)]
        [TestCase(0)]
        [TestCase(5)]
        public void ClassicGCD_OnlyZerosOrOnlyOneParameter_ThrowsArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.ClassicGCD(numbers));
        }


        [TestCase(0, 0)]
        
        public void ClassicGCD_TwoZeros_ThrowsArgumentException(int number1, int number2)
        {
            Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.ClassicGCD(number1,number2));
        }

        [TestCase(0, 0, 0)]

        public void ClassicGCD_ThreeZeros_ThrowsArgumentException(int number1, int number2,int number3)
        {
            Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.ClassicGCD(number1, number2, number3));
        }


        [TestCase(null)]
       
        public void ClassicGCD_NullParameter_ThrowsArgumentNullException(int[] numbers)
        {
            Assert.Throws<ArgumentNullException>(() => GreatestCommonDivisor.ClassicGCD(numbers));
        }
        #endregion

        #region BinaryGDC

        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(0, 100, ExpectedResult = 100)]
        [TestCase(0, -1, ExpectedResult = 1)]
        [TestCase(0, -10, ExpectedResult = 10)]
        [TestCase(-15, 55, ExpectedResult = 5)]
        [TestCase(-6, -9, ExpectedResult = 3)]
        [TestCase(13, 27, ExpectedResult = 1)]
        [TestCase(5, 5, ExpectedResult = 5)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, 1, ExpectedResult = 1)]
        public int BinaryGCD_TwoIntegerNumbers_PositiveTest(int number1, int number2)
        {

            return GreatestCommonDivisor.BinaryGCD(number1, number2);

        }

        [TestCase(0, 0, 1, ExpectedResult = 1)]
        [TestCase(0, 1, 0, ExpectedResult = 1)]
        [TestCase(1, 0, 0, ExpectedResult = 1)]
        [TestCase(0, 0, 100, ExpectedResult = 100)]
        [TestCase(-1, 0, 0, ExpectedResult = 1)]
        [TestCase(-10, 0, 0, ExpectedResult = 10)]
        [TestCase(-15, 10, 55, ExpectedResult = 5)]
        [TestCase(-15, 10, -15, ExpectedResult = 5)]
        [TestCase(-6, -18, -9, ExpectedResult = 3)]
        [TestCase(13, 15, 27, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, 1, int.MaxValue, ExpectedResult = 1)]
        public int BinaryGCD_ThreeIntegerNumbers_PositiveTest(int number1, int number2, int number3)
        {
            return GreatestCommonDivisor.BinaryGCD(number1, number2, number3);
        }



        [TestCase(0, 0, 0, 0, 1, ExpectedResult = 1)]
        [TestCase(0, 0, 0, 0, 100, ExpectedResult = 100)]
        [TestCase(0, 0, 0, 0, -1, ExpectedResult = 1)]
        [TestCase(0, 0, 0, 0, -10, ExpectedResult = 10)]
        [TestCase(-15, 5, 10, 55, 125, ExpectedResult = 5)]
        [TestCase(-6, -18, -3, -9, ExpectedResult = 3)]
        [TestCase(13, 15, 27, ExpectedResult = 1)]
        [TestCase(5, 5, ExpectedResult = 5)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, 1, int.MaxValue, int.MaxValue, ExpectedResult = 1)]

        public int BinaryGCD_MoreThanOneIntegerNumbers_PositiveTest(params int[] numbers)
        {

            return GreatestCommonDivisor.BinaryGCD(numbers);

        }


        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 0)]
        [TestCase(0)]
        [TestCase(5)]

        public void BinaryGCD_OnlyZerosOrOnlyOneParameter_ThrowsArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.BinaryGCD(numbers));
        }

        [TestCase(0, 0)]

        public void BinaryGCD_TwoZeros_ThrowsArgumentException(int number1, int number2)
        {
            Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.BinaryGCD(number1, number2));
        }

        [TestCase(0, 0, 0)]

        public void BinaryGCD_ThreeZeros_ThrowsArgumentException(int number1, int number2, int number3)
        {
            Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.BinaryGCD(number1, number2, number3));
        }


        [TestCase(null)]

        public void BinaryGCD_NullParameter_ThrowsArgumentNullException(int[] numbers)
        {
            Assert.Throws<ArgumentNullException>(() => GreatestCommonDivisor.BinaryGCD(numbers));
        }
        #endregion

    }
}
