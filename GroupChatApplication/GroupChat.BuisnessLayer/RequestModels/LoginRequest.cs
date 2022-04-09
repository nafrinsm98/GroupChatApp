using System;
using System.Collections.Generic;
using System.Text;

namespace GroupChat.BuisnessLayer.RequestModels
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
