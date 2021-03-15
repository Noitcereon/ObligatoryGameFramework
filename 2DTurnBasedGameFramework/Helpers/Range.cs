using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Helpers
{
    public struct Range
    {
        public int From { get; set; }
        public int To { get; set; }

        public Range(int from, int to)
        {
            From = from;
            To = to;
        }
    }
}
