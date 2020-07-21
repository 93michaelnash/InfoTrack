using InfoTrackProject.Helpers;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTrackProject.Services
{
    public class BingSearchScraper : SearchScraper
    {
        private const string UrlPrefix = "<a href=\"";
        private const string BingSearchPrefix = "https://www.bing.com.au/search?q=";
        private const string ResultsPrefix = "&count=";

        public override async Task<int> GetSiteHitsForKeyword(string query, string siteUrl, int results)
        {
            try
            {
                var htmlContent = await GetPageHtmlContent(UriHelpers.CreateSearchUrl(BingSearchPrefix, query, ResultsPrefix, results));
                var wellFormedUri = UriHelpers.CreateWellFormedUri(siteUrl);
                var siteToFind = $"{UrlPrefix}{wellFormedUri}";
                var occurences = StringHelpers.CheckLocationAndOccurrencesOfPatternInString(htmlContent, siteToFind);
                return occurences;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
