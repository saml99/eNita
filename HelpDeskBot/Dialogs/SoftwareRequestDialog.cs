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
    public class SoftwareRequestDialog : IDialog<object>
    {
        private BuildFormDelegate<SoftwareRequest> _newSoftwareRequest;

        public SoftwareRequestDialog(BuildFormDelegate<SoftwareRequest> newSoftwareRequest)
        {
            this._newSoftwareRequest = newSoftwareRequest;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<SoftwareRequest>(new SoftwareRequest(), this._newSoftwareRequest, FormOptions.PromptInStart);
            context.Call<SoftwareRequest>(enrollmentForm, Callback);
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