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
    public class AccessResetDialog : IDialog<object>
    {
        private BuildFormDelegate<AccessReset> _newAccessReset;

        public AccessResetDialog(BuildFormDelegate<AccessReset> newAccessReset)
        {
            this._newAccessReset = newAccessReset;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<AccessReset>(new AccessReset(), this._newAccessReset, FormOptions.PromptInStart);
            context.Call<AccessReset>(enrollmentForm, Callback);
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