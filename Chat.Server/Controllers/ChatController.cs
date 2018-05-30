﻿using System;
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
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View(new ChatViewModel() { OtherUser = "Paco" });
        }
    }
}