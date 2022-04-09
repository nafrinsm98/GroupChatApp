using System;
using System.Collections.Generic;
using System.Text;
using GroupChat.DataLayer.Models;

namespace GroupChat.DataLayer.Interface
{
    public interface IGroupRepository
    {
        public void AddGroup(Group user);
        public List<Group> GetGroup(int groupId);
    }
}
