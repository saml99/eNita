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
    public class SoftwareFaultDialog : IDialog<object>
    {
        private BuildFormDelegate<SoftwareFault> _newSoftwareFault;

        public SoftwareFaultDialog(BuildFormDelegate<SoftwareFault> newSoftwareFault)
        {
            this._newSoftwareFault = newSoftwareFault;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<SoftwareFault>(new SoftwareFault(), this._newSoftwareFault, FormOptions.PromptInStart);
            context.Call<SoftwareFault>(enrollmentForm, Callback);
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