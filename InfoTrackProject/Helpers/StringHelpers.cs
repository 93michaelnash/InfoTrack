using InfoTrackProject.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace InfoTrackProject.Helpers
{
    public static class StringHelpers
    {
        public static UrlOccurences FindOccurencesOfPatternAndUrlInContent(string content, string regexPattern, string urlToFind)
        {
            var regex = new Regex(regexPattern);

            var matches = regex.Matches(content).Cast<Match>().ToList();

            var indexes = matches.Select((x, i) => new { i, x })
                .Where(x => x.ToString().Contains(urlToFind))
                .Select(x => x.i + 1)
                .ToList();

            return new UrlOccurences
            {
                Count = indexes.Count(),
                Indexes = indexes
            };
        }
    }
}
