using InfoTrackProject.Helpers;
using System;
using System.Threading.Tasks;

namespace InfoTrackProject.Services
{
    public class GoogleSearchScraper : SearchScraper
    {
        private const string UrlPrefix = "<a href=\"/url?q=";
        private const string GoogleSearchPrefix = "https://www.google.com.au/search?q=";
        private const string ResultsPrefix = "&num=";

        public override async Task<int> GetSiteHitsForKeyword(string query, string siteUrl, int results)
        {
            try
            {
                var htmlContent = await GetPageHtmlContent(UriHelpers.CreateSearchUrl(GoogleSearchPrefix, query, ResultsPrefix, results));
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
