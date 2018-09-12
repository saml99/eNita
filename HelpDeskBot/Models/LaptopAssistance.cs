using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class LaptopAssistance
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<LaptopAssistance> BuildForm()
        {
            return new FormBuilder<LaptopAssistance>().Message("Please fill out an laptop assistance form").Build();
        }
    }
}