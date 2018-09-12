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
    public class FacilitiesFaultDialog : IDialog<object>
    {
        private BuildFormDelegate<FacilitiesFault> _newFacilitiesFault;

        public FacilitiesFaultDialog(BuildFormDelegate<FacilitiesFault> newFacilitiesFault)
        {
            this._newFacilitiesFault = newFacilitiesFault;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<FacilitiesFault>(new FacilitiesFault(), this._newFacilitiesFault, FormOptions.PromptInStart);
            context.Call<FacilitiesFault>(enrollmentForm, Callback);
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