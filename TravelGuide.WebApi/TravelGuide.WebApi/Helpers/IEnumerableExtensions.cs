using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelGuide.Core.Common.Entities;

namespace TravelGuide.WebApiNew.Helpers
{
    public static class EnumerableExtensions
    {
        public static List<SelectListItem> ToSelectItemList(this IEnumerable<City> list)
        {
            var newList = list
                .Select(city =>
                    new SelectListItem
                    {
                        Text = city.Name,
                        Value = city.Id.ToString(),
                        Selected = false,
                        Disabled = false
                    })
                .OrderBy(x => x.Value)
                .ToList();

            if (newList.Any())
            {
                newList.First().Selected = true;
            }

            return newList;
        }

        public static List<SelectListItem> ToSelectItemList(this IEnumerable<Route> list)
        {
            var newList = list
                .Select(route =>
                new SelectListItem
                {
                    Text = route.Name,
                    Value = route.Id.ToString(),
                    Selected = false,
                    Disabled = false
                })
                .OrderBy(x => x.Value)
                .ToList();

            if (newList.Any())
            {
                newList.First().Selected = true;
            }

            return newList;
        }
    }
}