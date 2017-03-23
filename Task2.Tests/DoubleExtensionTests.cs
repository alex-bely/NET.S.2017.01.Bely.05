using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Tests
{
    [TestFixture]
    public static class DoubleExtensionTests
    {
       
        [TestCase(5.0 / 0 - 8.0 / 0, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(112.25, ExpectedResult = "0100000001011100000100000000000000000000000000000000000000000000")]
        [TestCase(0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(1, ExpectedResult = "0011111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(2, ExpectedResult = "0100000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(-112.25, ExpectedResult = "1100000001011100000100000000000000000000000000000000000000000000")]
        [TestCase(0.1625, ExpectedResult = "0011111111000100110011001100110011001100110011001100110011001101")]
        [TestCase(340.57, ExpectedResult = "0100000001110101010010010001111010111000010100011110101110000101")]
        public static string ToBinaryRepresentation_NormalValuesAndSpecialValues_PositiveTest(double t)
        {
            return t.ToBinaryRepresentation();
           
        }
    }
}
