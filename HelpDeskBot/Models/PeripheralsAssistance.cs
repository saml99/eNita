using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class PeripheralsAssistance
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<PeripheralsAssistance> BuildForm()
        {
            return new FormBuilder<PeripheralsAssistance>().Message("Please fill out an peripherals assistance form").Build();
        }
    }
}