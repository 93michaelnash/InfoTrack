using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoTrackProject.Services
{
    public class Scraper
    {
        public Scraper()
        {

        }

        public async Task<int> FindKeywordResultsOnPage(string keyword, string url)
        {
            try
            {
                var htmlContent = await GetPageHtmlContent(keyword);
                var split = htmlContent.Split("<div class=\"g\"");
                var matchQuery = split.Where(x => x.ToLowerInvariant() == url.ToLowerInvariant()).Select(x => x);

                var occurences = CheckOccurrences(htmlContent, url);

                var count = matchQuery.Count();
                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int CheckOccurrences(string content, string pattern)
        {
            int count = 0;
            int a = 0;
            while ((a = content.IndexOf(pattern, a)) != -1)
            {
                a += pattern.Length;
                count++;
            }
            return count;
        }

        public async Task<string> GetPageHtmlContent(string query)
        {
            try
            {
                var client = new HttpClient();
                var htmlString = await client.GetStringAsync($"https://www.google.com.au/search?q={query}");
                return htmlString;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }
    }
}
