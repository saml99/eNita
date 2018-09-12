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
    public class ServerFaultDialog : IDialog<object>
    {
        private BuildFormDelegate<ServerFault> _newServerFault;

        public ServerFaultDialog(BuildFormDelegate<ServerFault> newServerFault)
        {
            this._newServerFault = newServerFault;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<ServerFault>(new ServerFault(), this._newServerFault, FormOptions.PromptInStart);
            context.Call<ServerFault>(enrollmentForm, Callback);
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