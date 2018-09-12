using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class AccessRevoke
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<AccessRevoke> BuildForm()
        {
            return new FormBuilder<AccessRevoke>().Message("Please fill out an access revoke form").Build();
        }
    }
}