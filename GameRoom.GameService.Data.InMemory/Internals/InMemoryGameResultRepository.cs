using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.InMemory
{
    internal class InMemoryGameResultRepository : IGameResultRepository
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

        public IEnumerable<GameResult> GetGameResultsForPlayer(Guid playerId)
        {
            return
                _GameResults.Where(
                    gameResult =>
                        gameResult.Team1.Players.Contains(playerId)
                        || gameResult.Team2.Players.Contains(playerId));
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
            var id = Guid.NewGuid();
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
