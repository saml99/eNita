using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HelpDeskBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            //context.PostAsync("Hi");
            context.Call(new LUISDialog(), MessageReceivedAsync);
            context.PostAsync("thanks");
            //context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            
            var message = await result;
            context.Done(message);
            //var activity = await result as Activity;
            //await context.Forward(new LUISDialog(), ResumeAfterLuisDialog, activity, CancellationToken.None);

            // calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;
            //
            //// return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            //
            //context.Wait(MessageReceivedAsync);

        }
    }
}