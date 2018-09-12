using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class AccessFailure
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<AccessFailure> BuildForm()
        {
            return new FormBuilder<AccessFailure>().Message("Please fill out an access revoke form").Build();
        }
    }
}