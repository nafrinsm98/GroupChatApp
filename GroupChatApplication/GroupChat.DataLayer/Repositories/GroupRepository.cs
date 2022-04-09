
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroupChat.DataLayer.Interface;
using GroupChat.DataLayer.Models;

namespace GroupChat.DataLayer.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        GroupChatDbContext dbContext;
        public GroupRepository(GroupChatDbContext context)
        {
            dbContext = context;
        }

        public void AddGroup(Group group)
        {
            dbContext.Add<Group>(group);
            dbContext.SaveChanges();
        }

        public List<Group> GetGroup(int groupId)
        {
            return dbContext.Group.Where(key => key.Id == groupId).ToList();
        }
    }
}
