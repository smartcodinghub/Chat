using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server.Models
{
    public class User
    {
        public string Name { get; set; }
        public string ConnectionId { get; set; }

        public User(string name, string connectionId)
        {
            Name = name;
            ConnectionId = connectionId;
        }
    }
}
