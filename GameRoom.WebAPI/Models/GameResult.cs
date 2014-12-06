using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameRoom.WebAPI.Models
{
    public class GameResult
    {
        public int Id { get; set; }

        public string GameType { get; set; }

        public TeamResult Team1 { get; set; }

        public TeamResult Team2 { get; set; }
    }

    public class TeamResult
    {
        public int Score { get; set; }

        public IList<int> Players { get; set; }
    }
}