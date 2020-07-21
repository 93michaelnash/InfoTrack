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
            var occurences = await scraper.GetSiteOccurencesForKeyword("online title search", "www.infotrack.com.au", 10);
            Assert.Equal(2, occurences.Count);
        }

        [Fact]
        public async void TestForOneHitOnPageOf10ResultsForBing()
        {
            var scraper = new BingSearchScraper();
            var occurences = await scraper.GetSiteOccurencesForKeyword("online title search", "infotrackgo.com.au", 10);
            Assert.Equal(1, occurences.Count);
        }
    }
}
