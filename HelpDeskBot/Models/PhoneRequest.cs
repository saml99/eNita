using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class PhoneRequest
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<PhoneRequest> BuildForm()
        {
            return new FormBuilder<PhoneRequest>().Message("Please fill out an phone request form").Build();
        }
    }
}