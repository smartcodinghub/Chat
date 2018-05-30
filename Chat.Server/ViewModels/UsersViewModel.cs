using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Server.Models;

namespace Chat.Server.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
