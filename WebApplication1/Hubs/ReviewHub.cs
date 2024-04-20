using Microsoft.AspNetCore.SignalR;

namespace OnlineShopping.Hubs
{
    public class ReviewHub:Hub
    {
        public async Task SendMessage(string fromUser ,string message)
        {
            await Clients.All.SendAsync("RecieveMessage",fromUser, message);
        }

    }
}
