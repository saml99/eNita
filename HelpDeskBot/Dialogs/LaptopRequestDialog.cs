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
    public class LaptopRequestDialog : IDialog<object>
    {
        private BuildFormDelegate<NewLaptop> _newLaptopRequest;

        public LaptopRequestDialog(BuildFormDelegate<NewLaptop> newLaptopRequest)
        {
            _newLaptopRequest = newLaptopRequest;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<NewLaptop>(new NewLaptop(), this._newLaptopRequest, FormOptions.PromptInStart);
            context.Call<NewLaptop>(enrollmentForm, Callback);
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