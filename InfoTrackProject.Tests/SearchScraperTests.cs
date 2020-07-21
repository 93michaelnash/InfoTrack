using InfoTrackProject.Services;
using System;
using Xunit;

namespace InfoTrackProject.Tests
{
    public class SearchScraperTests
    {
        [Fact]
        public async void TestForTwoHitsOnPageOf10ResultsForGoogle()
        {
            var scraper = new GoogleSearchScraper();
            var num = await scraper.GetSiteHitsForKeyword("online title search", "www.infotrack.com.au", 10);
            Assert.Equal(2, num);
        }

        [Fact]
        public async void TestForOneHitOnPageOf10ResultsForBing()
        {
            var scraper = new BingSearchScraper();
            var num = await scraper.GetSiteHitsForKeyword("online title search", "infotrackgo.com.au", 10);
            Assert.Equal(1, num);
        }
    }
}
