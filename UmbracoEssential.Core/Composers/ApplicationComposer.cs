using System;
using System.Web.Configuration;
using SlackBotMessages;
using SlackBotMessages.Models;
using Umbraco.Core.Composing;

namespace UmbracoEssential.Core.Composers
{
    public class ApplicationComposer : ComponentComposer<ApplicationComponent>, IUserComposer
    {
    }

    public class ApplicationComponent : IComponent
    {
        public void Initialize()
        {
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
                            Fallback = "Umbraco Essential started",
                            Color = "good",
                            Fields = new System.Collections.Generic.List<Field>
                            {
                                new Field
                                {
                                    Value = "Umbraco Essential started"
                                }
                            }
                        }
                    }
                };

                client.Send(message);
            }
            catch (Exception ex)
            {
                Current.Logger.Error(typeof(ApplicationComponent), ex, "Unable to send Slack message");
                throw ex;
            }
        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}
