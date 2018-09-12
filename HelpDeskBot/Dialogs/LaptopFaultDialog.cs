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
    public class LaptopFaultDialog : IDialog<object>
    {
        private BuildFormDelegate<LaptopFault> _newLaptopFault;

        public LaptopFaultDialog(BuildFormDelegate<LaptopFault> newLaptopFault)
        {
            this._newLaptopFault = newLaptopFault;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<LaptopFault>(new LaptopFault(), this._newLaptopFault, FormOptions.PromptInStart);
            context.Call<LaptopFault>(enrollmentForm, Callback);
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