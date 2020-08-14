using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace UmbracoEssential.Core.ViewModels
{
    public class ArticleResultSet
    {
        public IEnumerable<IPublishedContent> Results { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int PageCount{ get; set; }
        public bool IsArticleResultsPage { get; set; }
        public string Url { get; set; }
    }
}
