using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Conversions
{
    struct DistanceMetric
    {
        int foot;
        int inches;

        public DistanceMetric(int foot, int inches)
        {
            this.foot = foot;
            this.inches = inches;
        }

        public override string ToString() => $"{foot}'{inches}''";
    }
}
