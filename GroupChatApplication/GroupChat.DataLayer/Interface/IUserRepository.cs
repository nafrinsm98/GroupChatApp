using GroupChat.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupChat.DataLayer.Interface
{
    public interface IUserRepository
    {
        public void AddUsers(User user);

        public User GetUser(string UserName,string password);
    }
}
