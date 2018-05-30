using System.Collections.Generic;
using Chat.Server.Models;

namespace Chat.Server.Infraestructure.Data
{
    public interface IUserRepository
    {
        User Find(string name);
        IEnumerable<User> GetAll();
        void Register(string name, string connectionId);
        void Remove(string connectionId);
    }
}
