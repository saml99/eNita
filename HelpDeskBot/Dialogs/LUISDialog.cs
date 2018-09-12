using HelpDeskBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Connector;

namespace HelpDeskBot.Dialogs
{
    [LuisModel("eee9d94e-bf72-4ebd-a1af-037a46986d0a", "413a04ab5fdc446ba899657de64134d2", domain: "westus.api.cognitive.microsoft.com", Staging = true)]
    [Serializable]
    public class LUISDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry I dont know what you mean.");
            context.Wait(MessageReceived);
        }

        //Calls the GreetingDialog object
        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            context.Call(new GreetingDialog(), Callback);
        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

        //Creates a new Form that parses in the NewLaptop object from Models
        [LuisIntent("Laptop.Request")]
        public async Task NewLaptop(IDialogContext context, LuisResult result)
        {
            context.Call(new LaptopRequestDialog(Models.NewLaptop.BuildForm), Callback);
        }

        [LuisIntent("Laptop.Fault")]
        public async Task LaptopFault(IDialogContext context, LuisResult result)
        {
            context.Call(new LaptopFaultDialog(Models.LaptopFault.BuildForm), Callback);
        }

        [LuisIntent("Access.Failure")]
        public async Task AccessFailure(IDialogContext context, LuisResult result)
        {
            context.Call(new AccessFailureDialog(Models.AccessFailure.BuildForm), Callback);
        }

        [LuisIntent("Access.Request")]
        public async Task AccessRequest(IDialogContext context, LuisResult result)
        {
            context.Call(new AccessRequestDialog(Models.AccessRequest.BuildForm), Callback);
        }

        [LuisIntent("Access.Reset")]
        public async Task AccessReset(IDialogContext context, LuisResult result)
        {
            context.Call(new AccessResetDialog(Models.AccessReset.BuildForm), Callback);
        }

        [LuisIntent("Access.Revoke")]
        public async Task AccessRevoke(IDialogContext context, LuisResult result)
        {
            context.Call(new AccessRevokeDialog(Models.AccessRevoke.BuildForm), Callback);
        }

        [LuisIntent("Facilities.Assistance")]
        public async Task FacilitiesAssistance(IDialogContext context, LuisResult result)
        {
            context.Call(new FacilitiesAssistanceDialog(Models.FacilitiesAssistance.BuildForm), Callback);
        }

        [LuisIntent("Facilities.Fault")]
        public async Task FacilitiesFault(IDialogContext context, LuisResult result)
        {
            context.Call(new FacilitiesFaultDialog(Models.FacilitiesFault.BuildForm), Callback);
        }

        [LuisIntent("Laptop.Assistance")]
        public async Task LaptopAssistance(IDialogContext context, LuisResult result)
        {
            context.Call(new LaptopAssistanceDialog(Models.LaptopAssistance.BuildForm), Callback);
        }

        [LuisIntent("Network.Assistance")]
        public async Task NetworkAssistance(IDialogContext context, LuisResult result)
        {
            context.Call(new NetworkAssistanceDialog(Models.NetworkAssistance.BuildForm), Callback);
        }

        [LuisIntent("Network.Fault")]
        public async Task NetworkFault(IDialogContext context, LuisResult result)
        {
            context.Call(new NetworkFaultDialog(Models.NetworkFault.BuildForm), Callback);
        }

        [LuisIntent("Peripherals.Assistance")]
        public async Task PeripheralsAssistance(IDialogContext context, LuisResult result)
        {
            context.Call(new PeripheralsAssistanceDialog(Models.PeripheralsAssistance.BuildForm), Callback);
        }

        [LuisIntent("Peripherals.Fault")]
        public async Task PeripheralsFault(IDialogContext context, LuisResult result)
        {
            context.Call(new PeripheralsFaultDialog(Models.PeripheralsFault.BuildForm), Callback);
        }

        [LuisIntent("Peripherals.Request")]
        public async Task PeripheralsRequest(IDialogContext context, LuisResult result)
        {
            context.Call(new PeripheralsRequestDialog(Models.PeripheralsRequest.BuildForm), Callback);
        }

        [LuisIntent("Phone.Assistance")]
        public async Task PhoneAssistance(IDialogContext context, LuisResult result)
        {
            context.Call(new PhoneAssistanceDialog(Models.PhoneAssistance.BuildForm), Callback);
        }

        [LuisIntent("Phone.Request")]
        public async Task PhoneRequest(IDialogContext context, LuisResult result)
        {
            context.Call(new PhoneRequestDialog(Models.PhoneRequest.BuildForm), Callback);
        }

        [LuisIntent("Security.Assistance")]
        public async Task SecurityAssistance(IDialogContext context, LuisResult result)
        {
            context.Call(new SecurityAssistanceDialog(Models.SecurityAssistance.BuildForm), Callback);
        }

        [LuisIntent("Server.Assistance")]
        public async Task ServerAssistance(IDialogContext context, LuisResult result)
        {
            context.Call(new ServerAssistanceDialog(Models.ServerAssistance.BuildForm), Callback);
        }

        [LuisIntent("Server.Fault")]
        public async Task ServerFault(IDialogContext context, LuisResult result)
        {
            context.Call(new ServerFaultDialog(Models.ServerFault.BuildForm), Callback);
        }

        [LuisIntent("Software.Assistance")]
        public async Task SoftwareAssistance(IDialogContext context, LuisResult result)
        {
            context.Call(new SoftwareAssistanceDialog(Models.SoftwareAssistance.BuildForm), Callback);
        }

        [LuisIntent("Software.Fault")]
        public async Task SoftwareFault(IDialogContext context, LuisResult result)
        {
            context.Call(new SoftwareFaultDialog(Models.SoftwareFault.BuildForm), Callback);
        }

        [LuisIntent("Software.Request")]
        public async Task SoftwareRequest(IDialogContext context, LuisResult result)
        {
            context.Call(new SoftwareRequestDialog(Models.SoftwareRequest.BuildForm), Callback);
        }
    }
}