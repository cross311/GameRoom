using System;

namespace GameRoom.GameService.Data.Models
{
    public class GameResult
    {
        private readonly Guid _Id;
        private readonly string _GameType;
        private readonly TeamResult _Team1;
        private readonly TeamResult _Team2;

        public GameResult(string gameType, TeamResult team1, TeamResult team2)
            : this(Guid.Empty, gameType, team1, team2)
        {
        }

        public GameResult(Guid id, string gameType, TeamResult team1, TeamResult team2)
        {
            if (gameType == null) throw new ArgumentNullException("gameType");
            if (team1 == null) throw new ArgumentNullException("team1");
            if (team2 == null) throw new ArgumentNullException("team2");

            _Id = id;
            _GameType = gameType;
            _Team1 = team1;
            _Team2 = team2;
        }

        public string GameType
        {
            get { return _GameType; }
        }

        public TeamResult Team1
        {
            get { return _Team1; }
        }

        public TeamResult Team2
        {
            get { return _Team2; }
        }

        public Guid Id
        {
            get { return _Id; }
        }

        public bool IsNewGame()
        {
            return _Id == Guid.Empty;
        }
    }
}
