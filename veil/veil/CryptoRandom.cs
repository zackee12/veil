using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace veil
{
    class CryptoRandom : RandomNumberGenerator
    {
        private static RandomNumberGenerator rng;

        public CryptoRandom()
        {
            rng = RandomNumberGenerator.Create();
        }

        public override void GetBytes(byte[] data)
        {
            rng.GetBytes(data);
        }

        public override void GetNonZeroBytes(byte[] data)
        {
            rng.GetNonZeroBytes(data);
        }

        public int Next()
        {
            // return a non negative random integer
            return Next(0, Int32.MaxValue);
        }

        public int Next(int maxVal)
        {
            // return a positive int < maxVal
            return Next(0, maxVal);
        }

        public int Next(int minVal, int maxVal)
        {
            // return a random int [min max)
            return (int)((long)Math.Floor(NextDouble() * ((long) maxVal - (long) minVal)) + minVal);
        }

        public double NextDouble()
        {
            // generate random int byte and convert to double in range [0 1]
            byte[] rInt = new byte[4];
            rng.GetBytes(rInt);
            return (double)BitConverter.ToUInt32(rInt, 0) / (double)UInt32.MaxValue;
        }


    }
}
