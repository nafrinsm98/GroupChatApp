using System;
using System.Collections.Generic;
using System.Text;
using EntityModel = GroupChat.BuisnessLayer.Entities;
using DataModel = GroupChat.DataLayer.Models;
using AutoMapper;

namespace GroupChat.BuisnessLayer.Utility
{
    public class GroupChatProfile : Profile
    {
        public GroupChatProfile()
        {
            CreateMap<DataModel.Group, EntityModel.Group>();
            CreateMap<DataModel.GroupMessage, EntityModel.GroupMessage>();
            CreateMap<DataModel.User, EntityModel.User>();
        }
    }
}
