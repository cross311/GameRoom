using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameRoom.GameService
{
    public class GameResult
    {
        private readonly GameType _GameType;
        private readonly TeamResult _Team1;
        private readonly TeamResult _Team2;

        public GameResult(GameType gameType, TeamResult team1, TeamResult team2)
        {
            if (gameType == null) throw new ArgumentNullException("gameType");
            if (team1 == null) throw new ArgumentNullException("team1");
            if (team2 == null) throw new ArgumentNullException("team2");

            _GameType = gameType;
            _Team1 = team1;
            _Team2 = team2;
        }

        public GameType GameType
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
    }

    public class TeamResult
    {
        private readonly int _Score;
        private readonly IList<int> _Players;

        public TeamResult(int score, IList<int> players)
        {
            if (players == null) throw new ArgumentNullException("players");

            _Score = score;
            _Players = players;
        }

        public int Score
        {
            get { return _Score; }
        }

        public IList<int> Players
        {
            get { return _Players; }
        }
    }

    public class GameType
    {
        private readonly string _Name;

        public GameType(string name)
        {
            _Name = name;
        }

        public string Name
        {
            get { return _Name; }
        }

        public static GameType Foosball = new GameType("Foosball");
        public static GameType Pool = new GameType("Pool");
        public static GameType Fifa = new GameType("Fifa");
    }

    public interface IGameTypeRepository
    {
        IList<GameType> GetGameTypes();
    }

    public interface IGameResultRepository
    {
        IEnumerable<GameResult> GetGameResults();

        IEnumerable<GameResult> GetGameResultsForPlayer(int player);

        IEnumerable<GameResult> GetGameResultsForGameType(GameType gameType);

        GameResult RecordGameResults(GameResult gameResult);
    }
}
