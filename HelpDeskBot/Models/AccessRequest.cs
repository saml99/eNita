using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class AccessRequest
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<AccessRequest> BuildForm()
        {
            return new FormBuilder<AccessRequest>().Message("Please fill out an access request form").Build();
        }
    }
}