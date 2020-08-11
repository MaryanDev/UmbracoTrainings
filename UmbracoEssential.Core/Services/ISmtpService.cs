using UmbracoEssential.Core.ViewModels;

namespace UmbracoEssential.Core.Services
{
    public interface ISmtpService
    {
        bool SendEmail(ContactViewModel model);
    }
}
