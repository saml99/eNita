using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class NetworkAssistance
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<NetworkAssistance> BuildForm()
        {
            return new FormBuilder<NetworkAssistance>().Message("Please fill out an network assistance form").Build();
        }
    }
}