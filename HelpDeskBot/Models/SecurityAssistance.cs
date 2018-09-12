using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class SecurityAssistance
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<SecurityAssistance> BuildForm()
        {
            return new FormBuilder<SecurityAssistance>().Message("Please fill out an security assistance form").Build();
        }
    }
}