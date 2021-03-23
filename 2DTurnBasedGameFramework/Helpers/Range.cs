using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Helpers
{
    /// <summary>
    /// Contains properties for From and To. Both are inclusive.
    /// Example use: a damage range, where it deals dmg between 3-6 (3 would be From, 6 would be To)
    /// </summary>
    public struct Range
    {
        /// <summary>
        /// Start of the range.
        /// </summary>
        public int From { get; set; }
        /// <summary>
        /// End of the range.
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// Sets the From and To properties.
        /// </summary>
        public Range(int from, int to)
        {
            From = from;
            To = to;
        }
    }
}
