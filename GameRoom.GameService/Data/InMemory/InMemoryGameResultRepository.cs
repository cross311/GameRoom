using System;
using System.Collections.Generic;
using System.Linq;

namespace GameRoom.GameService.Data
{
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