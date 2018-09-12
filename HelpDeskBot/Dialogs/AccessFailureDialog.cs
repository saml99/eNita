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
    public class AccessFailureDialog : IDialog<object>
    {
        private BuildFormDelegate<AccessFailure> _newAccessFailure;

        public AccessFailureDialog(BuildFormDelegate<AccessFailure> newAccessFailure)
        {
            this._newAccessFailure = newAccessFailure;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<AccessFailure>(new AccessFailure(), this._newAccessFailure, FormOptions.PromptInStart);
            context.Call<AccessFailure>(enrollmentForm, Callback);
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