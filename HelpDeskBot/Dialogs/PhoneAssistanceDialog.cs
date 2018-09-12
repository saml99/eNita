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
    public class PhoneAssistanceDialog : IDialog<object>
    {
        private BuildFormDelegate<PhoneAssistance> _newPhoneAssistance;

        public PhoneAssistanceDialog(BuildFormDelegate<PhoneAssistance> newPhoneAssistance)
        {
            this._newPhoneAssistance = newPhoneAssistance;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<PhoneAssistance>(new PhoneAssistance(), this._newPhoneAssistance, FormOptions.PromptInStart);
            context.Call<PhoneAssistance>(enrollmentForm, Callback);
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