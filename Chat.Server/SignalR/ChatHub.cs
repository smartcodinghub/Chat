using System;
using System.Threading.Tasks;
using Chat.Server.Infraestructure.Data;
using Chat.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.SignalR
{
    /// <summary>
    /// Hub para el tiempo real
    /// </summary>
    [Authorize]
    public class ChatHub : Hub<IChatClient>
    {
        /// <summary>
        /// Ruta donde este hub escucha
        /// </summary>
        public const String Path = "/chathub";

        private IUserRepository repository;

        public ChatHub(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Send(string to, String message)
        {
            var senderName = Context.User.Identity.Name;
            User toUser = repository.Find(to);

            if(toUser == null) return false;

            await Clients.Client(toUser.ConnectionId)
                .Received(senderName, DateTime.Now, message);

            return true;
        }

        public override async Task OnConnectedAsync()
        {
            var senderName = Context.User.Identity.Name;
            repository.Update(senderName, Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            repository.Update(Context.User.Identity.Name, null);

            await base.OnDisconnectedAsync(exception);
        }
    }

    /// <summary>
    /// Interfaz para tipar los clientes de un hub
    /// </summary>
    public interface IChatClient
    {
        /// <summary>
        /// Mensaje "Event"
        /// </summary>
        /// <param name="time"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        Task Received(string userName, DateTime time, String message);
    }
}
