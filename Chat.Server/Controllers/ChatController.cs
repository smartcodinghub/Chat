using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Server.Infraestructure.Data;
using Chat.Server.Models;
using Chat.Server.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ChatController : Controller
    {
        [HttpGet]
        [Route("{user}")]
        public IActionResult With(string user)
        {
            return View(new ChatViewModel() { OtherUser = user });
        }
    }
}