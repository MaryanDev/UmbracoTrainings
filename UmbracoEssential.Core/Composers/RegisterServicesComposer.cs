using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoEssential.Core.Services;

namespace UmbracoEssential.Core.Composers
{
    public class RegisterServicesComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<ISmtpService, SmtpService>(Lifetime.Singleton);
            composition.Register<IArticleService, ArticleService>(Lifetime.Request);
        }
    }
}
