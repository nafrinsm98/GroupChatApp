using GroupChat.DataLayer.Interface;
using GroupChat.DataLayer.Models;
using GroupChat.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupChat.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GroupChatDbContext groupDbContext;
        private IUserRepository userRepository;
        private IGroupRepository groupRepository;
        private IGroupMessageRepository groupMessageRepository;

        public IUserRepository User
        {

            get
            {

                if (null == userRepository)
                {
                    userRepository = new UserRepository(groupDbContext);
                }

                return userRepository;
            }

        }

        public IGroupRepository Group
        {
            get
            {
                if(null == groupRepository)
                {
                    groupRepository = new GroupRepository(groupDbContext);
                }

                return groupRepository;
            }
        }

        public IGroupMessageRepository GroupMessage
        {
            get
            {
                if(null == groupMessageRepository)
                {
                    groupMessageRepository = new GroupMessageRepository(groupDbContext);
                }

                return groupMessageRepository;
            }
        }
    }
}
