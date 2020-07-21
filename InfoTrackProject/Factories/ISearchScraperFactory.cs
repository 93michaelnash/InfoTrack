using InfoTrackProject.Services;

namespace InfoTrackProject.Factories
{
    public interface ISearchScraperFactory
    {
        ISearchScraper GetSearchScraperFor(string searchProvider);
    }
}