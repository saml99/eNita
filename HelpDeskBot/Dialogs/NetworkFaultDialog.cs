﻿using HelpDeskBot.Models;
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
    public class NetworkFaultDialog : IDialog<object>
    {
        private BuildFormDelegate<NetworkFault> _newNetworkFault;

        public NetworkFaultDialog(BuildFormDelegate<NetworkFault> newNetworkFault)
        {
            this._newNetworkFault = newNetworkFault;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<NetworkFault>(new NetworkFault(), this._newNetworkFault, FormOptions.PromptInStart);
            context.Call<NetworkFault>(enrollmentForm, Callback);
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