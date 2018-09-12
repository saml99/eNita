using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class PhoneAssistance
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<PhoneAssistance> BuildForm()
        {
            return new FormBuilder<PhoneAssistance>().Message("Please fill out an phone assistance form").Build();
        }
    }
}