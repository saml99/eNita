using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class PeripheralsRequest
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<PeripheralsRequest> BuildForm()
        {
            return new FormBuilder<PeripheralsRequest>().Message("Please fill out an peripherals request form").Build();
        }
    }
}