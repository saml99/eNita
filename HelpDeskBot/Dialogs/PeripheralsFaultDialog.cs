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
    public class PeripheralsFaultDialog : IDialog<object>
    {
        private BuildFormDelegate<PeripheralsFault> _newPeripheralsFault;

        public PeripheralsFaultDialog(BuildFormDelegate<PeripheralsFault> newPeripheralsFault)
        {
            this._newPeripheralsFault = newPeripheralsFault;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<PeripheralsFault>(new PeripheralsFault(), this._newPeripheralsFault, FormOptions.PromptInStart);
            context.Call<PeripheralsFault>(enrollmentForm, Callback);
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