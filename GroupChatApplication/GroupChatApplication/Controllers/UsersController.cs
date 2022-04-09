using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupChat.BuisnessLayer.Interface;
using EntityModel = GroupChat.BuisnessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using RequestModel = GroupChat.BuisnessLayer.RequestModels;

namespace GroupChatApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices userServices;
        public UsersController(IUserServices service)
        {
            userServices = service;
        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<string> CreateUser(EntityModel.User user)
        {
            return await userServices.CreateUser(user);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        [Produces("application/json")]

        public async Task<IActionResult> Login(RequestModel.LoginRequest loginRequest)
        {
            EntityModel.User user = userServices.Login(loginRequest.UserName,loginRequest.Password);
            if (user != null)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
