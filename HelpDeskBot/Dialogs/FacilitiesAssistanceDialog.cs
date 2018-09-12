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
    public class FacilitiesAssistanceDialog : IDialog<object>
    {
        private BuildFormDelegate<FacilitiesAssistance> _newFacilitiesAssistance;

        public FacilitiesAssistanceDialog(BuildFormDelegate<FacilitiesAssistance> newFacilitiesAssistance)
        {
            this._newFacilitiesAssistance = newFacilitiesAssistance;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<FacilitiesAssistance>(new FacilitiesAssistance(), this._newFacilitiesAssistance, FormOptions.PromptInStart);
            context.Call<FacilitiesAssistance>(enrollmentForm, Callback);
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