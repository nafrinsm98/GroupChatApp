using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EntityModel = GroupChat.BuisnessLayer.Entities;
using RequestModel = GroupChat.BuisnessLayer.RequestModels;

namespace GroupChat.BuisnessLayer.Interface
{
    public interface IUserServices
    {
        public Task<string> CreateUser(EntityModel.User user);
        public EntityModel.User Login(string userName,string password);
    }
}
