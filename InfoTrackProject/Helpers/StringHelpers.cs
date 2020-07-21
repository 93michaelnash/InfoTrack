using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTrackProject.Helpers
{
    public static class StringHelpers
    {
        public static int CheckLocationAndOccurrencesOfPatternInString(string content, string pattern)
        {
            int count = 0, x = 0;
            while ((x = content.IndexOf(pattern, x)) != -1)
            {
                x += pattern.Length;
                count++;
            }
            return count;
        }

    }
}
