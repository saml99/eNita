using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class ServerAssistance
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<ServerAssistance> BuildForm()
        {
            return new FormBuilder<ServerAssistance>().Message("Please fill out an server assistance form").Build();
        }
    }
}