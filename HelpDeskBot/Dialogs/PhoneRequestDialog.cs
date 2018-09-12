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
    public class PhoneRequestDialog : IDialog<object>
    {
        private BuildFormDelegate<PhoneRequest> _newPhoneRequest;

        public PhoneRequestDialog(BuildFormDelegate<PhoneRequest> newPhoneRequest)
        {
            this._newPhoneRequest = newPhoneRequest;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<PhoneRequest>(new PhoneRequest(), this._newPhoneRequest, FormOptions.PromptInStart);
            context.Call<PhoneRequest>(enrollmentForm, Callback);
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