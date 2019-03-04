using System;
using System.Collections.Generic;
using System.Text;

namespace SamplesLibrary
{
    public static class OverflowUnderflow
    {
        public static void DoIt()
        {
            uint max = uint.MaxValue;
            uint min = uint.MinValue;

            Console.WriteLine($"max: { max}, min: {min}");
            checked
            {
                max++;
                min--;
            }
            Console.WriteLine($"max: { max}, min: {min}");
        }
    }
}
