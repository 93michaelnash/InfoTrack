using System;

namespace InfoTrackProject.Helpers
{
    public static class UriHelpers
    {
        public static Uri CreateSearchUrl(string prefix, string query = null, string resultsPrefix = null, int? resultsAmount = null)
        {
            return new Uri($"{prefix}{query}{resultsPrefix}{resultsAmount}");
        }
    }
}
