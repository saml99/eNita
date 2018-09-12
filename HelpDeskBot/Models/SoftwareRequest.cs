using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class SoftwareRequest
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<SoftwareRequest> BuildForm()
        {
            return new FormBuilder<SoftwareRequest>().Message("Please fill out an software request form").Build();
        }
    }
}