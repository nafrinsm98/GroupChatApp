using System;
using System.Collections.Generic;
using System.Text;
using GroupChat.DataLayer.Models;
using GroupChat.DataLayer.Interface;
using System.Linq;

namespace GroupChat.DataLayer.Repositories
{
    public class GroupMessageRepository : IGroupMessageRepository
    {
        GroupChatDbContext dbContext;

        public GroupMessageRepository(GroupChatDbContext context)
        {
            dbContext = context;
        }
        public void SendMessages(GroupMessage groupMessage)
        {
            dbContext.Add<GroupMessage>(groupMessage);
            dbContext.SaveChanges();
        }

        public List<GroupMessage> GetGroupMessges(int groupId,int userId)
        {
            return dbContext.GroupMessage.Where(key => key.Id == groupId && key.UserId == userId).ToList();
        }
    }
}
