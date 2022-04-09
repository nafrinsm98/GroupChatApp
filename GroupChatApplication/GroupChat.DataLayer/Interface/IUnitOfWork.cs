using System;
using System.Collections.Generic;
using System.Text;

namespace GroupChat.DataLayer.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IGroupRepository Group { get; }
        IGroupMessageRepository GroupMessage { get;}
    }
}
