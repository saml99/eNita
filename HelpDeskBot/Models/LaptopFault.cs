using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class LaptopFault
    {
        public enum FaultType
        {
            Bitlocker = 1,
            Hardware = 2,
            Performance = 3,
            Power = 4,
            Other = 5
        }

        [Prompt("What is your laptop number?")]
        public string LaptopNumber;
        [Prompt("What is your issue related to? {||}")]
        public FaultType Fault;
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<LaptopFault> BuildForm()
        {
            return new FormBuilder<LaptopFault>().Message("Please fill out a laptop fault form").Build();
        }
    }
}