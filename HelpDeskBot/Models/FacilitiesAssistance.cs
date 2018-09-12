using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class FacilitiesAssistance
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<FacilitiesAssistance> BuildForm()
        {
            return new FormBuilder<FacilitiesAssistance>().Message("Please fill out an facilities assistance form").Build();
        }
    }
}