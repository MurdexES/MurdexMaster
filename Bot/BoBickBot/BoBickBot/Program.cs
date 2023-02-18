using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

Console.WriteLine("Done");

var client = new TelegramBotClient("5912026715:AAGX-Iu6lkpOFNt_wKf5o3UJ03vCMREce8g");
client.StartReceiving(Update, Error);

async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
{
    var message = update.Message;
    if (message.Text != null)
    {
        if (message.Text.ToLower().Contains("hello there"))
        {
            await botClient.SendTextMessageAsync(message.Chat.Id, "Fuck you there!");
            return;
        }
    }
}

Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
{
    throw new NotImplementedException();
}

