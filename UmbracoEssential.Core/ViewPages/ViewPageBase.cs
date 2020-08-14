using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;
using UmbracoEssential.Core.Services;
using Current = Umbraco.Web.Composing.Current;

namespace UmbracoEssential.Core.ViewPages
{
    public abstract class ViewPageBase<T> : UmbracoViewPage<T>
    {
        public readonly IArticleService ArticleService;
        public ViewPageBase() : this(
            Current.Factory.GetInstance<IArticleService>(),
            Current.Factory.GetInstance<ServiceContext>(),
            Current.Factory.GetInstance<AppCaches>()
            )
        {
        }
        public ViewPageBase(IArticleService articleService, ServiceContext services, AppCaches appCaches)
        {
            ArticleService = articleService;
            Services = services;
            AppCaches = appCaches;
        }

        protected override void InitializePage()
        {
            base.InitializePage();
        }
    }
    public abstract class ViewPageBase : UmbracoViewPage
    {
        public readonly IArticleService ArticleService;
        public ViewPageBase() : this(
            Current.Factory.GetInstance<IArticleService>(),
            Current.Factory.GetInstance<ServiceContext>(),
            Current.Factory.GetInstance<AppCaches>()
            )
        { }

        public ViewPageBase(IArticleService articleService, ServiceContext services, AppCaches appCaches)
        {
            ArticleService = articleService;
            Services = services;
            AppCaches = appCaches;
        }

        protected override void InitializePage()
        {
            base.InitializePage();
        }
    }
}
