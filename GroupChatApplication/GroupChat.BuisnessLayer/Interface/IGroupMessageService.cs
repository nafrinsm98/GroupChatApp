using System;
using System.Collections.Generic;
using System.Text;
using EntityModel = GroupChat.BuisnessLayer.Entities;

namespace GroupChat.BuisnessLayer.Interface
{
    public interface IGroupMessageService
    {
        public bool SendMessages(EntityModel.GroupMessage groupMessage);
        public List<EntityModel.GroupMessage> GetGroupMessges(int groupId,int userId);
    }
}
