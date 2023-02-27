using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SimpleCalculator : ISimpleCalculator
    {
        public int Add(int start, int amount)
        {
            long result = (long)start + (long)amount;

            if (result > int.MaxValue || result < int.MinValue)
            {
                //Throw an exception if the result would overflow
                throw new ArithmeticException();
            }

            return (int)result;
        }

        public int Subtract(int start, int amount)
        {
            long result = (long)start - (long)amount;

            if (result > int.MaxValue || result < int.MinValue)
            {
                //Throw an exception if the result would overflow
                throw new ArithmeticException();
            }

            return (int)result;
        }
    }
}
