using System.Collections.Concurrent;
using System.Collections.Generic;
using Chat.Server.Models;

namespace Chat.Server.Infraestructure.Data
{
    public class UserRepository : IUserRepository
    {
        private static ConcurrentDictionary<string, User> users = new ConcurrentDictionary<string, User>();

        public User Find(string name) => users[name];

        public IEnumerable<User> GetAll() => users.Values;

        public void Register(string name, string connectionId) => users.TryAdd(name, new User(name, connectionId));

        public void Remove(string name) => users.TryRemove(name, out User user);
    }
}
