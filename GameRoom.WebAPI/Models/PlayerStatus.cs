using System;

namespace GameRoom.WebAPI.Models
{
    public class PlayerStatus
    {
        public int Player { get; set; }

        public string State { get; set; }

        public string Message { get; set; }

        public DateTime? Reported { get; set; }
    }
}