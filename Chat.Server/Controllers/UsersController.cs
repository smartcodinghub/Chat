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
    public class UsersController : Controller
    {
        private IUserRepository repository;

        public UsersController(IUserRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(new UsersViewModel { Users = repository.GetAll().Append(new User("Paco", "Pep")).Append(new User("Paco1", "Pep")).Append(new User("Paco2", "Pep")) });
        }
    }
}