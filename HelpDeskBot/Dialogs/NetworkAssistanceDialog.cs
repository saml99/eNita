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
    public class NetworkAssistanceDialog : IDialog<object>
    {
        private BuildFormDelegate<NetworkAssistance> _newNetworkAssistance;

        public NetworkAssistanceDialog(BuildFormDelegate<NetworkAssistance> newNetworkAssistance)
        {
            this._newNetworkAssistance = newNetworkAssistance;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<NetworkAssistance>(new NetworkAssistance(), this._newNetworkAssistance, FormOptions.PromptInStart);
            context.Call<NetworkAssistance>(enrollmentForm, Callback);
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