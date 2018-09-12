using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class PeripheralsFault
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<PeripheralsFault> BuildForm()
        {
            return new FormBuilder<PeripheralsFault>().Message("Please fill out an peripherals fault form").Build();
        }
    }
}