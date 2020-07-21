using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrackProject.Services
{
    public abstract class SearchScraper : ISearchScraper, IDisposable
    {
        internal HttpClient _client;

        public SearchScraper()
        {
            _client = new HttpClient();
        }

        public abstract Task<int> GetSiteHitsForKeyword(string query, string siteUrl, int results);

        internal async Task<string> GetPageHtmlContent(Uri url)
        {
            try
            {
                var htmlString = await _client.GetStringAsync(url);
                return htmlString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}