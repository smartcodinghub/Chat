using System.Collections.Concurrent;
using System.Collections.Generic;
using Chat.Server.Models;

namespace Chat.Server.Infraestructure.Data
{
    public class UserRepository : IUserRepository
    {
        private static ConcurrentDictionary<string, User> users = new ConcurrentDictionary<string, User>();

        public User Find(string name) => users.TryGetValue(name, out User user) ? user : null;

        public IEnumerable<User> GetAll() => users.Values;

        public void Register(string name) => users.TryAdd(name, new User(name));

        public void Remove(string name) => users.TryRemove(name, out User user);

        public bool Update(string name, string connectionId)
        {
            if(users.TryGetValue(name, out User user))
            {
                user.ConnectionId = connectionId;
                return true;
            }

            return false;
        }
    }
}
