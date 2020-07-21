using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackProject.Helpers
{
    public static class UriHelpers
    {
        public static Uri CreateWellFormedUri(string url)
        {
            try
            {
                return new UriBuilder(url) { Scheme = Uri.UriSchemeHttps, Port = -1 }.Uri;
            }
            catch (Exception ex)
            {
                throw new UriFormatException(ex.Message);
            }
        }

        public static Uri CreateSearchUrl(string prefix, string query = null, string resultsPrefix = null, int? resultsAmount = null)
        {
            return new Uri($"{prefix}{query}{resultsPrefix}{resultsAmount}");
        }
    }
}
