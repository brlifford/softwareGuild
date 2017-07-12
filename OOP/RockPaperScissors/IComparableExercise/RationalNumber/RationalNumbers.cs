using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{

    public class RationalNumbers : IComparable<RationalNumbers>
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumbers(int a, int b)
        {
            Numerator = a;
            Denominator = b;
        }

        public int CompareTo(RationalNumbers that)
        {
            int effectiveThis = this.Numerator * that.Denominator;
            int effectiveThat = this.Denominator * that.Numerator;

            return effectiveThat.CompareTo(effectiveThis);
        }
    }
}
