using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Conversions
{
    struct DistanceSI
    {
        private int meters;
        private int centimeters;

        public int Meters
        {
            get => meters;
            set
            {
                meters = value >= 0 ? value : throw new ArgumentOutOfRangeException();
            }
        }


        public int Centimeters
        {
            get => centimeters;
            set
            {
                centimeters = value >= 0 && value <= 100? value : throw new ArgumentOutOfRangeException();
            }
        }

        public double TotalMeters => Meters + (double)centimeters / 100;

        public int TotalCentimeters => Meters * 100 + centimeters;

        public DistanceSI(int meters, int centimeters)
        {
            this.meters = this.centimeters = 0;
            Meters = meters;
            Centimeters = centimeters;
        }

        public DistanceSI(double meters)
        {
            this.meters = this.centimeters = 0;
            Meters = (int)meters;
            Centimeters = (int)((meters - Meters) * 100);
        }

        public static implicit operator DistanceMetric(DistanceSI thisDistance)
        {
            Console.WriteLine("Converting to metric units");
            // the logic is not accurate
            var totalCms = thisDistance.TotalCentimeters;
            var totalInches = totalCms / 2.54;
            var totalFeet = totalInches / 12;
            var wholeFeet = (int)totalFeet;
            var remainingInches = (int)Math.Round(totalFeet - wholeFeet);
            var metricDistance = new DistanceMetric(wholeFeet, remainingInches);
            return metricDistance;
        }
    }
}
