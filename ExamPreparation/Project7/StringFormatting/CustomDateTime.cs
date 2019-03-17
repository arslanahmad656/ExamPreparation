using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7.StringFormatting
{
    struct CustomDateTime : IFormattable
    {
        /*
         * Following format are supported:
         * F: Full date (Long)
         * f: Full date (short)
         * T: Time (Long)
         * t: Time (short)
         * dt: Full date time,
         */

        private DateTime date;

        public CustomDateTime(DateTime date)
        {
            this.date = date;
        }

        public override string ToString()
        {
            return ToString("dt", null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "dt";
            }

            switch (format)
            {
                case "F":
                    return date.ToLongDateString();
                case "f":
                    return date.ToShortDateString();
                case "T":
                    return date.ToLongTimeString();
                case "t":
                    return date.ToShortTimeString();
                case "dt":
                    return date.ToString();
                default:
                    throw new FormatException($"Format specifier {format} is unknown.");
            }
        }
    }
}
