using System;
using System.Linq;
using System.Web;

namespace GameRoom.WebAPI.Models
{
    public class GameResult
    {
        public Guid Id { get; set; }

        public string GameType { get; set; }

        public TeamResult Team1 { get; set; }

        public TeamResult Team2 { get; set; }
    }
}