using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InfoTrackProject.Models
{
    public class SearchViewModel
    {
        public string Keywords { get; set; }
        public string URL { get; set; }
        
        public List<SearchOption> SearchOptions {get;set;}
        public List<SelectListItem> ResultCountOptions { get; set; }

        public SearchOption SelectedSearchOption { get; set; }
        public SelectListItem SelectedResultCount { get; set; }
    }
}
