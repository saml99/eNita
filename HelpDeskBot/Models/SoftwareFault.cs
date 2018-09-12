using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class SoftwareFault
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<SoftwareFault> BuildForm()
        {
            return new FormBuilder<SoftwareFault>().Message("Please fill out an software fault form").Build();
        }
    }
}