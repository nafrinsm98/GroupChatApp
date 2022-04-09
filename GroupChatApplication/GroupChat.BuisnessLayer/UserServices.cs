using GroupChat.BuisnessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using GroupChat.DataLayer.Interface;
using System.Threading.Tasks;
using EntityModel = GroupChat.BuisnessLayer.Entities;
using DataModel = GroupChat.DataLayer.Models;
using AutoMapper;

namespace GroupChat.BuisnessLayer
{
    public class UserServices : IUserServices
    {
        private IUnitOfWork unitOfWork;
        private IConfiguration configuration;
        private IMapper mapper;
        public UserServices(IUnitOfWork uow, IConfiguration config,IMapper map)
        {
            unitOfWork = uow;
            configuration = config;
            mapper = map;
        }

        public async Task<string> CreateUser(EntityModel.User user)
        {
            try
            {
                DataModel.User userDataModel = new DataModel.User() {
                    Name = user.Name,
                    UserName = user.UserName,
                    Password = user.Password,
                    EmailAddress = user.EmailAddress,
                    CreatedAt = DateTime.UtcNow,
                };

                unitOfWork.User.AddUsers(userDataModel);

                return "User Created Successfully";
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public EntityModel.User Login(string userName, string password)
        {
            try
            {
                EntityModel.User user = mapper.Map<DataModel.User, EntityModel.User>(unitOfWork.User.GetUser(userName, password));
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
