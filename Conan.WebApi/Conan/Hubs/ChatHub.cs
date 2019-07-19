using System.Threading.Tasks;
using Conan.Data.Models;
using Microsoft.AspNetCore.SignalR;

namespace Conan.Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}