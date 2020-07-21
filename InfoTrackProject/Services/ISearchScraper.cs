using System;
using System.Threading.Tasks;

namespace InfoTrackProject.Services
{
    public interface ISearchScraper 
    {
        Task<int> GetSiteHitsForKeyword(string query, string siteUrl, int results);
    }
}