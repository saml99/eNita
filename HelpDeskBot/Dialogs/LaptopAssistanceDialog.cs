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
    public class LaptopAssistanceDialog : IDialog<object>
    {
        private BuildFormDelegate<LaptopAssistance> _newLaptopAssistance;

        public LaptopAssistanceDialog(BuildFormDelegate<LaptopAssistance> newLaptopAssistance)
        {
            this._newLaptopAssistance = newLaptopAssistance;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<LaptopAssistance>(new LaptopAssistance(), this._newLaptopAssistance, FormOptions.PromptInStart);
            context.Call<LaptopAssistance>(enrollmentForm, Callback);
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