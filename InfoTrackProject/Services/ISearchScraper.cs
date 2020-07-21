using InfoTrackProject.Models;
using System.Threading.Tasks;

namespace InfoTrackProject.Services
{
    public interface ISearchScraper 
    {
        Task<UrlOccurences> GetSiteOccurencesForKeyword(string query, string siteUrl, int results);
    }
}