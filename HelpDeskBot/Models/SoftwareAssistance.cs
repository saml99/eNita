using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class SoftwareAssistance
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<SoftwareAssistance> BuildForm()
        {
            return new FormBuilder<SoftwareAssistance>().Message("Please fill out an software assistance form").Build();
        }
    }
}