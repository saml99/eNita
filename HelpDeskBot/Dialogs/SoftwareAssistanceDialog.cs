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
    public class SoftwareAssistanceDialog : IDialog<object>
    {
        private BuildFormDelegate<SoftwareAssistance> _newSoftwareAssistance;

        public SoftwareAssistanceDialog(BuildFormDelegate<SoftwareAssistance> newSoftwareAssistance)
        {
            this._newSoftwareAssistance = newSoftwareAssistance;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<SoftwareAssistance>(new SoftwareAssistance(), this._newSoftwareAssistance, FormOptions.PromptInStart);
            context.Call<SoftwareAssistance>(enrollmentForm, Callback);
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