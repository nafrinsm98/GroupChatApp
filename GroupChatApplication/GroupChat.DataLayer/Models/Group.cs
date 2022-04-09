using System;
using System.Collections.Generic;
using System.Text;

namespace GroupChat.DataLayer.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
