using System.Collections.Generic;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using UmbracoEssential.Core.ViewModels;

namespace UmbracoEssential.Core.Services
{
    public interface IArticleService
    {
        IPublishedContent GetArticleListPage(IPublishedContent siteRoot);
        IEnumerable<IPublishedContent> GetLatestArticles(IPublishedContent siteRoot);
        ArticleResultSet GetLatestArticles(IPublishedContent currentContentItem, HttpRequestBase request);
    }
}
