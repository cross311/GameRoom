using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoom.GameService.Data
{
    public class GameResult
    {
        private const int _UnsavedGameResultId = 0;
        private readonly int _Id;
        private readonly string _GameType;
        private readonly TeamResult _Team1;
        private readonly TeamResult _Team2;

        public GameResult(string gameType, TeamResult team1, TeamResult team2)
            : this(_UnsavedGameResultId, gameType, team1, team2)
        {
        }

        public GameResult(int id, string gameType, TeamResult team1, TeamResult team2)
        {
            if(id < _UnsavedGameResultId) throw new ArgumentOutOfRangeException("id", "id must not be less then zero");
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

        public int Id
        {
            get { return _Id; }
        }

        public bool IsNewGame()
        {
            return Id == _UnsavedGameResultId;
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

    public interface IGameResultRepository
    {
        IEnumerable<GameResult> GetGameResults();

        IEnumerable<GameResult> GetGameResultsForPlayer(int player);

        IEnumerable<GameResult> GetGameResultsForGameType(string gameType);

        GameResult RecordGameResults(GameResult gameResult);

        GameResult UpdateGameResults(GameResult gameResult);
    }

    public class InMemoryGameResultRepository : IGameResultRepository
    {
        private readonly IList<GameResult> _GameResults;

        public InMemoryGameResultRepository()
        {
            _GameResults = new List<GameResult>();
        }

        public IEnumerable<GameResult> GetGameResults()
        {
            return _GameResults;
        }

        public IEnumerable<GameResult> GetGameResultsForPlayer(int player)
        {
            return
                _GameResults.Where(
                    gameResult => 
                        gameResult.Team1.Players.Contains(player)
                        || gameResult.Team2.Players.Contains(player));
        }

        public IEnumerable<GameResult> GetGameResultsForGameType(string gameType)
        {
            return
                _GameResults.Where(
                    gameResult =>
                        gameResult.GameType == gameType);
        }

        public GameResult RecordGameResults(GameResult gameResult)
        {
            var id = _GameResults.Count + 1;
            var newGameResult = new GameResult(id, gameResult.GameType, gameResult.Team1, gameResult.Team2);
            _GameResults.Add(newGameResult);
            return newGameResult;
        }


        public GameResult UpdateGameResults(GameResult gameResult)
        {
            if (gameResult.IsNewGame())
                throw new ArgumentOutOfRangeException("gameResult", "must not be an unsaved game");

            var inMemoryGame = _GameResults.SingleOrDefault(gr => gr.Id == gameResult.Id);

            if (ReferenceEquals(inMemoryGame, null))
                return null;

            _GameResults.Add(gameResult);
            _GameResults.Remove(inMemoryGame);

            return gameResult;
        }
    }

}
