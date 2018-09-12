using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class ServerFault
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<ServerFault> BuildForm()
        {
            return new FormBuilder<ServerFault>().Message("Please fill out an server fault form").Build();
        }
    }
}