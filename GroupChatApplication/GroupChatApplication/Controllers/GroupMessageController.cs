using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupChat.BuisnessLayer.Interface;
using EntityModel = GroupChat.BuisnessLayer.Entities;


namespace GroupChatApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMessageController : ControllerBase
    {
        private readonly IGroupMessageService groupMessageService;
        public GroupMessageController(IGroupMessageService service)
        {
            groupMessageService = service;
        }

        [HttpPost]
        [Produces("application/json")]
        public bool SendMessages(EntityModel.GroupMessage groupMessage)
        {
            return  groupMessageService.SendMessages(groupMessage);
        }

        [HttpGet]
        [Route("{groupId}/{userId}")]
        [Produces("application/json")]

        public List<EntityModel.GroupMessage> GetGroup(int groupId,int userId)
        {
            return groupMessageService.GetGroupMessges(groupId, userId);
        }
    }
}
