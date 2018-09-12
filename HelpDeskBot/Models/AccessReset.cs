using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class AccessReset
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<AccessReset> BuildForm()
        {
            return new FormBuilder<AccessReset>().Message("Please fill out an access reset form").Build();
        }
    }
}