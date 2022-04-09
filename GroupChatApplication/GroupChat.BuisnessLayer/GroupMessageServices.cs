using System;
using System.Collections.Generic;
using System.Text;
using GroupChat.BuisnessLayer.Interface;
using Microsoft.Extensions.Configuration;
using GroupChat.DataLayer.Interface;
using EntityModel = GroupChat.BuisnessLayer.Entities;
using DataModel = GroupChat.DataLayer.Models;
using AutoMapper;

namespace GroupChat.BuisnessLayer
{
    public class GroupMessageServices : IGroupMessageService
    {
        private IUnitOfWork unitOfWork;
        private IConfiguration configuration;
        private IMapper mapper;


        public GroupMessageServices(IUnitOfWork uow, IConfiguration config, IMapper map)
        {
            unitOfWork = uow;
            configuration = config;
            mapper = map;
        }

        public  bool SendMessages(EntityModel.GroupMessage groupMessage)
        {
            try
            {
                DataModel.GroupMessage groupMessageDataModel = new DataModel.GroupMessage() {
                    GroupId = groupMessage.GroupId,
                    UserId = groupMessage.UserId,
                    Message = groupMessage.Message,
                    CreatedAt = DateTime.UtcNow,
                };

                unitOfWork.GroupMessage.SendMessages(groupMessageDataModel);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<EntityModel.GroupMessage> GetGroupMessges(int groupId,int userId)
        {
            try
            {
                List<EntityModel.GroupMessage> messages = mapper.Map<List<DataModel.GroupMessage>, List<EntityModel.GroupMessage>>(unitOfWork.GroupMessage.GetGroupMessges(groupId, userId));
                return messages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
