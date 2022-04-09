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
    public class GroupController : ControllerBase
    {
        private readonly IGroupServices groupServices;
        public GroupController(IGroupServices service)
        {
            groupServices = service;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<string> CreateGroup(EntityModel.Group group)
        {
            return await groupServices.CreateGroup(group);
        }

        [HttpGet]
        [Route("{groupId}")]
        [Produces("application/json")]

        public List<EntityModel.Group> GetGroup(int groupId)
        {
            return  groupServices.GetGroup(groupId);
        }

    }
}
