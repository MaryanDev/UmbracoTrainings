using System.Web;

namespace UmbracoEssential.Core.Helpers
{
    public static class QueryStringHelper
    {
        public static int GetNumberFromQueryStr(HttpRequestBase request, string key, int fallbackValue = 0)
        {
            var strValue = request.QueryString[key];
            if (!string.IsNullOrWhiteSpace(strValue) && int.TryParse(strValue, out int numericValue))
            {
                return numericValue;
            }

            return fallbackValue;
        }
    }
}
