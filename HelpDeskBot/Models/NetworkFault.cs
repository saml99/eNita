using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class NetworkFault
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<NetworkFault> BuildForm()
        {
            return new FormBuilder<NetworkFault>().Message("Please fill out an network fault form").Build();
        }
    }
}