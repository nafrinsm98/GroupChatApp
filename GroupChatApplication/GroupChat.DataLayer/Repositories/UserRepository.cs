using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupChat.DataLayer.Interface;
using GroupChat.DataLayer.Models;

namespace GroupChat.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        GroupChatDbContext dbContext;
        public UserRepository(GroupChatDbContext context)
        {
            dbContext = context;
        }

        public void AddUsers(User user)
        {
            dbContext.Add<User>(user);
            dbContext.SaveChanges();
        }

        public User GetUser(string userName,string password)
        {
            return dbContext.User.First(key => key.UserName == userName && key.Password == password);
        }
    }
}
