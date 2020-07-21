using InfoTrackProject.Enums;
using InfoTrackProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackProject.Factories
{
    public class SearchScraperFactory : ISearchScraperFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SearchScraperFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISearchScraper GetSearchScraperFor(string searchProvider)
        {
            switch (searchProvider)
            {
                case nameof(SearchEnum.Bing):
                    return (ISearchScraper)_serviceProvider.GetService(typeof(BingSearchScraper));
                case nameof(SearchEnum.Google):
                    return (ISearchScraper)_serviceProvider.GetService(typeof(GoogleSearchScraper));
                default:
                    throw new Exception("Incorrect search provider.");
            }
        }
    }
}
