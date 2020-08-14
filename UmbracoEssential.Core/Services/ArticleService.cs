using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using UmbracoEssential.Core.Helpers;
using UmbracoEssential.Core.ViewModels;

namespace UmbracoEssential.Core.Services
{
    public class ArticleService : IArticleService
    {
        public IPublishedContent GetArticleListPage(IPublishedContent siteRoot)
        {
            return siteRoot.Descendants().FirstOrDefault(x => x.ContentType.Alias == "articleList");
        }

        public IEnumerable<IPublishedContent> GetLatestArticles(IPublishedContent siteRoot)
        {
            var articleList = GetArticleListPage(siteRoot);

            return articleList.Descendants()
                .Where(x => x.ContentType.Alias == "article" && x.IsVisible())
                .OrderByDescending(x => x.Value<DateTime>("articleDate"));
        }

        public ArticleResultSet GetLatestArticles(IPublishedContent currentContentItem, HttpRequestBase request)
        {
            var siteRoot = currentContentItem.Root();
            var articleList = GetArticleListPage(siteRoot);
            var articles = articleList.Descendants()
                .Where(x => x.ContentType.Alias == "article" && x.IsVisible())
                .OrderByDescending(x => x.Value<DateTime>("articleDate"));

            var isArticleListPage = articleList.Id == currentContentItem.Id;
            var fallbackPageSize = isArticleListPage ? 10 : 3;

            var pageNumber = QueryStringHelper.GetNumberFromQueryStr(request, "page", 1);
            var pageSize = QueryStringHelper.GetNumberFromQueryStr(request, "size", fallbackPageSize);

            var pageOfArticles = articles.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            var totalItemCount = articles.Count();
            var pageCount = totalItemCount > 0 ? Math.Ceiling((double)totalItemCount / pageSize) : 1;

            return new ArticleResultSet
            {
                PageCount = (int)pageCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Results = pageOfArticles,
                IsArticleResultsPage = isArticleListPage,
                Url = articleList.Url
            };
        }
    }
}
