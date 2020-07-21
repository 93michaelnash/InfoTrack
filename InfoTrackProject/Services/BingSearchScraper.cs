using InfoTrackProject.Helpers;
using InfoTrackProject.Models;
using System;
using System.Threading.Tasks;

namespace InfoTrackProject.Services
{
    public class BingSearchScraper : SearchScraper
    {
        private const string BingRegexPattern = "<li class=\"b_algo\">(.*?)</li>";
        private const string BingSearchPrefix = "https://www.bing.com.au/search?q=";
        private const string ResultsPrefix = "&count=";

        public override async Task<UrlOccurences> GetSiteOccurencesForKeyword(string query, string siteUrl, int results)
        {
            try
            {
                var htmlContent = await GetPageHtmlContent(UriHelpers.CreateSearchUrl(BingSearchPrefix, query, ResultsPrefix, results));
                var occurences = StringHelpers.FindOccurencesOfPatternAndUrlInContent(htmlContent, BingRegexPattern, siteUrl);
                return occurences;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
