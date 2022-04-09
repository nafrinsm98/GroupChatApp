using System;
using System.Collections.Generic;
using System.Text;

namespace GroupChat.BuisnessLayer.Entities
{
    public class GroupMessage
    {
        //public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        //public DateTime CreatedAt { get; set; }
    }
}
