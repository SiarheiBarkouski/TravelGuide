using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelGuide.WebApiNew.Models.GoogleMap;


namespace TravelGuide.WebApiNew.Helpers
{
    public static class HtmlHelpers
    {
        private static IHtmlContent GoogleMap(IHtmlHelper helper, string id, Map map, bool editor)
        {
            var htmlGenericControl1 = new TagBuilder("div");
            var htmlGenericControl2 = new TagBuilder("div");
            htmlGenericControl2.Attributes.Add("class", "map-container");
            htmlGenericControl2.Attributes.Add(nameof(id), $"{id}");
            if (map.height > 0 || map.width > 0)
            {
                var format1 = "width:{0}px;";
                var str1 = map.width <= 0 ? string.Empty : string.Format(format1, map.width);
                var format2 = "height:{0}px;";
                var str2 = map.height <= 0 ? string.Empty : string.Format(format2, map.height);
                htmlGenericControl2.Attributes.Add("style", str1 + str2);
            }
            htmlGenericControl1.InnerHtml.SetHtmlContent(htmlGenericControl2);

            var htmlInputHidden1 = new TagBuilder("div");
            var htmlInputHidden2 = new TagBuilder("div");
            htmlInputHidden2.Attributes.Add("id", id);
            htmlInputHidden2.AddCssClass("display: none");
            htmlGenericControl1.InnerHtml.AppendHtml(htmlInputHidden1);
            htmlGenericControl1.InnerHtml.AppendHtml(htmlInputHidden2);

            var htmlGenericControl3 = new TagBuilder("script");
            htmlGenericControl3.Attributes.Add("type", "text/javascript");
            htmlGenericControl3.InnerHtml.SetHtmlContent(
                $"$(document).ready(function(){{\r\n$('#{id}').GoogleMapEditor($.extend({{}},{map.ToJsonString()},{{dataChange:function(sender, data){{ $(sender.container).next().next().val(data); }}}}));}});");
            htmlGenericControl1.InnerHtml.AppendHtml(htmlGenericControl3);

            return htmlGenericControl1;
        }

        public static IHtmlContent GoogleMapEditor(this IHtmlHelper helper, string id, Map map)
        {
            return GoogleMap(helper, id, map, true);
        }
    }
}
