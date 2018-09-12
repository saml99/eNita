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
    public class PeripheralsAssistanceDialog : IDialog<object>
    {
        private BuildFormDelegate<PeripheralsAssistance> _newPeripheralsAssistance;

        public PeripheralsAssistanceDialog(BuildFormDelegate<PeripheralsAssistance> newPeripheralsAssistance)
        {
            this._newPeripheralsAssistance = newPeripheralsAssistance;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<PeripheralsAssistance>(new PeripheralsAssistance(), this._newPeripheralsAssistance, FormOptions.PromptInStart);
            context.Call<PeripheralsAssistance>(enrollmentForm, Callback);
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