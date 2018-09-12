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
    public class AccessRequestDialog : IDialog<object>
    {
        private BuildFormDelegate<AccessRequest> _newAccessRequest;

        public AccessRequestDialog(BuildFormDelegate<AccessRequest> newAccessRequest)
        {
            this._newAccessRequest = newAccessRequest;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<AccessRequest>(new AccessRequest(), this._newAccessRequest, FormOptions.PromptInStart);
            context.Call<AccessRequest>(enrollmentForm, Callback);
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