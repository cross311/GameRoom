using System;
using System.Collections.Generic;

namespace GameRoom.GameService.Data.Models
{
    public class TeamResult
    {
        private readonly int _Score;
        private readonly IList<Guid> _Players;

        public TeamResult(int score, IList<Guid> players)
        {
            if (players == null) throw new ArgumentNullException("players");

            _Score = score;
            _Players = players;
        }

        public int Score
        {
            get { return _Score; }
        }

        public IList<Guid> Players
        {
            get { return _Players; }
        }
    }
}