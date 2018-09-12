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
    public class AccessRevokeDialog : IDialog<object>
    {
        private BuildFormDelegate<AccessRevoke> _newAccessRevoke;

        public AccessRevokeDialog(BuildFormDelegate<AccessRevoke> newAccessRevoke)
        {
            this._newAccessRevoke = newAccessRevoke;
        }

        public async Task StartAsync(IDialogContext context)
        {
            var enrollmentForm = new FormDialog<AccessRevoke>(new AccessRevoke(), this._newAccessRevoke, FormOptions.PromptInStart);
            context.Call<AccessRevoke>(enrollmentForm, Callback);
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