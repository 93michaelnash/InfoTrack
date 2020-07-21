using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrackProject.Helpers
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> CreateSelectListFromIntArray(int[] arr, bool selectFirst = false)
        {
            var list = new List<SelectListItem>();
            foreach(var item in arr)
            {
                list.Add(new SelectListItem { Value = $"{item}", Text = $"{item}", Selected = selectFirst });
                selectFirst = false;
            }
            
            return list;
        }
    }
}
