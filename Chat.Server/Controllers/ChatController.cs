using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View(new ChatViewModel() { OtherUser = "Paco" });
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}