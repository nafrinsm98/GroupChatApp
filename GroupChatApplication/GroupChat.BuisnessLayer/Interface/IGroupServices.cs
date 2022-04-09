using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EntityModel = GroupChat.BuisnessLayer.Entities;

namespace GroupChat.BuisnessLayer.Interface
{
    public interface IGroupServices
    {
        public Task<string> CreateGroup(EntityModel.Group group);

        public List<EntityModel.Group> GetGroup(int groupId);

    }
}
