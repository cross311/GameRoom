using System;
using System.Collections.Generic;

namespace GameRoom.WebAPI.Models
{
    public class TeamResult
    {
        public int Score { get; set; }

        public IList<Guid> Players { get; set; }
    }
}