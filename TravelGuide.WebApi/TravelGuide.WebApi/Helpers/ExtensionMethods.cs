using Newtonsoft.Json;
using TravelGuide.WebApiNew.Models.GoogleMap;

namespace TravelGuide.WebApiNew.Helpers
{
    public static class GoogleMapExtensionMethods
    {
        public static string ToJsonString(this Map map)
        {
            return JsonConvert.SerializeObject(map);
        }

        public static Map ToMapObject(this string mapjson)
        {
            return JsonConvert.DeserializeObject<Map>(mapjson);
        }
    }
}