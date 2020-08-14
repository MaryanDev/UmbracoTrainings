using SlackBotMessages;
using SlackBotMessages.Models;
using System;
using System.Web;
using System.Web.Configuration;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace UmbracoEssential.Core.Application
{
    public class CustomGlobal : UmbracoApplication
    {
        protected override void OnApplicationError(object sender, EventArgs evargs)
        {
            var request = HttpContext.Current.Request;
            var error = HttpContext.Current.Server.GetLastError();

            try
            {
                var client = new SbmClient(WebConfigurationManager.AppSettings["SlackBotMessagesWebHookUrl"]);

                var message = new Message
                {
                    Username = "Marian Maikher",
                    IconEmoji = ":robot_face:",
                    Attachments = new System.Collections.Generic.List<Attachment>
                    {
                        new Attachment
                        {
                            Fallback = error.Message,
                            Color = "danger",
                            Fields = new System.Collections.Generic.List<Field>
                            {
                                new Field
                                {
                                    Title = Emoji.Warning + " Error",
                                    Value = error.Message
                                },
                                new Field
                                {
                                    Title = "Stack Trace",
                                    Value = error.StackTrace
                                },
                                new Field
                                {
                                    Title = "Url",
                                    Value = request.Url.GetLeftPart(UriPartial.Authority) + request.Url
                                }
                            }
                        }
                    }
                };

                client.Send(message);
            }
            catch (Exception ex)
            {
                Current.Logger.Error(typeof(CustomGlobal), ex, "Unable to send slack notification");

            }

            base.OnApplicationError(sender, evargs);
        }
    }
}
