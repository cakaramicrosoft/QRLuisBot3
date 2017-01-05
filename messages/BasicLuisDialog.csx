using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Sorry I don't understand. You said: {result.Query}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("greeting")]
    public async Task MyIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"Hello! How can I help you today?"); //
        context.Wait(MessageReceived);
    }
    [LuisIntent("flightbooking")]
    public async Task MyIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"I can do that! Can you tell me your arrival/departure dates and destination please?"); //
        
        context.Wait(MessageReceived);
    }
}