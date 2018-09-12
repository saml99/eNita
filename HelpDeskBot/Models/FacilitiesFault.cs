using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class FacilitiesFault
    {
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<FacilitiesFault> BuildForm()
        {
            return new FormBuilder<FacilitiesFault>().Message("Please fill out an facilities fault form").Build();
        }
    }
}