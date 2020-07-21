using System;
using System.Collections.Generic;
using System.Linq;

namespace InfoTrackProject.Helpers
{
    public static class EnumHelpers
    {
        public static IEnumerable<T> ConvertEnumToList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
