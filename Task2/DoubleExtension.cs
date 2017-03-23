using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Provides extension method for binary representation of
    /// double-precision floating-point value
    /// </summary>
    public static class DoubleExtension
    {
        #region Public member
        /// <summary>
        /// Returns the binary representation of the number in string format.
        /// </summary>
        /// <param name="number">Source double-precision floating-point value</param>
        /// <returns>The string with binary representation</returns>
        
        public static string ToBinaryRepresentation(this double number)
        {
           
            if (Double.IsNegativeInfinity(number)) return Convert.ToString(BitConverter.DoubleToInt64Bits(Double.NegativeInfinity), 2).PadLeft(64, '0');
            if (Double.IsPositiveInfinity(number)) return Convert.ToString(BitConverter.DoubleToInt64Bits(Double.PositiveInfinity), 2).PadLeft(64, '0');
            if (Double.IsNaN(number)) return Convert.ToString(BitConverter.DoubleToInt64Bits(Double.NaN), 2).PadLeft(64, '0');
            return BinaryRepr(number);
        }
        #endregion

        #region Private member


        /// <summary>
        /// Returns the binary representation of the number in string format.
        /// </summary>
        /// <param name="number">Source double-precision floating-point value</param>
        /// <returns>The string with binary representation</returns>

        private static string BinaryRepr(double number)
        {

             double temp = number;

             var raw = BitConverter.DoubleToInt64Bits(temp);
            
             var sign = (raw>>63) & 1;
            
             var exponent =(raw >> 52) & (long)Math.Pow(2,11)-1;

             var mantissa = (raw & (long)Math.Pow(2, 52) - 1);

            string binaryNumber = Convert.ToString(sign, 2) + Convert.ToString(exponent, 2).PadLeft(11, '0') + Convert.ToString(mantissa, 2).PadLeft(52, '0');

            return binaryNumber;

        }
        #endregion

    }
}
