using System;
using System.Collections.Generic;
using System.Text;
using GroupChat.BuisnessLayer.Interface;
using Microsoft.Extensions.Configuration;
using GroupChat.DataLayer.Interface;
using System.Threading.Tasks;
using EntityModel = GroupChat.BuisnessLayer.Entities;
using DataModel = GroupChat.DataLayer.Models;
using AutoMapper;

namespace GroupChat.BuisnessLayer
{
    public class GroupService : IGroupServices
    {
        private IUnitOfWork unitOfWork;
        private IConfiguration configuration;
        private IMapper mapper;

        public GroupService(IUnitOfWork uow, IConfiguration config, IMapper map)
        {
            unitOfWork = uow;
            configuration = config;
            mapper = map;
        }

        public async Task<string> CreateGroup(EntityModel.Group group)
        {
            try{

                DataModel.Group groupDataModel = new DataModel.Group() { GroupName = group.GroupName, UserId = group.UserId, CreatedAt = DateTime.UtcNow };
                unitOfWork.Group.AddGroup(groupDataModel);
                return "Group Created Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EntityModel.Group> GetGroup(int groupId)
        {
            try
            {
                List<EntityModel.Group> group = mapper.Map<List<DataModel.Group>, List<EntityModel.Group>>(unitOfWork.Group.GetGroup(groupId));
                return group;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
