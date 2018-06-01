using System;
using System.Threading.Tasks;
using Chat.Server.Infraestructure.Data;
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
        public const String Path = "/chathub";
    }

    /// <summary>
    /// Interfaz para tipar los clientes de un hub
    /// </summary>
    public interface IChatClient
    {
    }
}
