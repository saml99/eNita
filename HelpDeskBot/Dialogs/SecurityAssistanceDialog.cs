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
    public class SecurityAssistanceDialog : IDialog<object>
    {
        private BuildFormDelegate<SecurityAssistance> _newSecurityAssistance;

        public SecurityAssistanceDialog(BuildFormDelegate<SecurityAssistance> newSecurityAssistance)
        {
            this._newSecurityAssistance = newSecurityAssistance;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<SecurityAssistance>(new SecurityAssistance(), this._newSecurityAssistance, FormOptions.PromptInStart);
            context.Call<SecurityAssistance>(enrollmentForm, Callback);
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