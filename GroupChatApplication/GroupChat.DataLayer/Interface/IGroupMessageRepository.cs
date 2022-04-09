using System;
using System.Collections.Generic;
using System.Text;
using GroupChat.DataLayer.Models;

namespace GroupChat.DataLayer.Interface
{
    public interface IGroupMessageRepository
    {
        public void SendMessages(GroupMessage groupMessage);
        public List<GroupMessage> GetGroupMessges(int groupId,int userId); 
    }
}
