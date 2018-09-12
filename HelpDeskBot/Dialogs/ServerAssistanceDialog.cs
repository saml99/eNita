using HelpDeskBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpDeskBot.Dialogs
{
    [Serializable]
    public class ServerAssistanceDialog : IDialog<object>
    {
        private BuildFormDelegate<ServerAssistance> _newServerAssistance;

        public ServerAssistanceDialog(BuildFormDelegate<ServerAssistance> newServerAssistance)
        {
            this._newServerAssistance = newServerAssistance;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<ServerAssistance>(new ServerAssistance(), this._newServerAssistance, FormOptions.PromptInStart);
            context.Call<ServerAssistance>(enrollmentForm, Callback);
        }

        private async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            context.Done(message);
        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }
    }
}