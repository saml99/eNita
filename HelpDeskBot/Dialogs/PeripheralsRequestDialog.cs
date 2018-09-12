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
    public class PeripheralsRequestDialog : IDialog<object>
    {
        private BuildFormDelegate<PeripheralsRequest> _newPeripheralsRequest;

        public PeripheralsRequestDialog(BuildFormDelegate<PeripheralsRequest> newPeripheralsRequest)
        {
            this._newPeripheralsRequest = newPeripheralsRequest;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<PeripheralsRequest>(new PeripheralsRequest(), this._newPeripheralsRequest, FormOptions.PromptInStart);
            context.Call<PeripheralsRequest>(enrollmentForm, Callback);
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