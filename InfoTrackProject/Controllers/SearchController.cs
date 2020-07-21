using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InfoTrackProject.Models;
using InfoTrackProject.Enums;
using InfoTrackProject.Helpers;
using InfoTrackProject.Factories;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InfoTrackProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchScraperFactory _searchScraperFactory;

        public SearchController(ILogger<SearchController> logger, ISearchScraperFactory searchScraperFactory)
        {
            _logger = logger;
            _searchScraperFactory = searchScraperFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new SearchViewModel
            {
                SearchOptions = new List<SearchOption>(EnumHelpers.ConvertEnumToList<SearchEnum>().Select(x => new SearchOption(x.ToString()))),
                ResultCountOptions = SelectListHelper.CreateSelectListFromIntArray(new[] { 100, 50, 20, 10 }, true),
                SelectedSearchOption = new SearchOption(SearchEnum.Google.ToString())
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> GetHits(SearchViewModel model)
        {
            try
            {
                _logger.LogInformation($"Getting site hits for keywords: {model.Keywords}, site: {model.URL} using {model.SelectedSearchOption.Name}");
                var scraper = _searchScraperFactory.GetSearchScraperFor(model.SelectedSearchOption.Name);
                var hits = await scraper.GetSiteHitsForKeyword(model.Keywords, model.URL, Convert.ToInt32(model.SelectedResultCount.Value));
                return new JsonResult(hits);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(ex.Message) { StatusCode = 400 };
            }
        }
    }
}
