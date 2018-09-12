using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDeskBot.Models
{
    [Serializable]
    public class NewLaptop
    {
        public enum ReasonType
        {
            Faulty = 1,
            Slow = 2,
            Lost = 3,
            Expired = 4,
            Other = 5
        }

        [Prompt("Enter your manager's name")]
        public string Manager;
        [Prompt("What is your laptop number?")]
        public string LaptopNumber;       
        [Prompt("Why do you need a new laptop? {||}")]
        public ReasonType Reason;
        [Prompt("Please describe the issue in more detail.")]
        public string Description;

        public static IForm<NewLaptop> BuildForm()
        {
            return new FormBuilder<NewLaptop>().Message("Please fill out a new laptop request").Build();
        }
    }
}