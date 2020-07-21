using InfoTrackProject.Helpers;
using InfoTrackProject.Models;
using System;
using System.Threading.Tasks;

namespace InfoTrackProject.Services
{
    public class GoogleSearchScraper : SearchScraper
    {
        private const string GoogleRegexPattern = "<div class=\"ZINbbc xpd O9g5cc uUPGi\">(.*?)</div>";
        private const string GoogleSearchPrefix = "https://www.google.com.au/search?q=";
        private const string ResultsPrefix = "&num=";

        public override async Task<UrlOccurences> GetSiteOccurencesForKeyword(string query, string siteUrl, int results)
        {
            try
            {
                var htmlContent = await GetPageHtmlContent(UriHelpers.CreateSearchUrl(GoogleSearchPrefix, query, ResultsPrefix, results));
                var occurences = StringHelpers.FindOccurencesOfPatternAndUrlInContent(htmlContent, GoogleRegexPattern, siteUrl);
                return occurences;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
