using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class GameResultRepository : IGameResultRepository
    {
        private Orchestrate.Net.Orchestrate _Orchestrate;

        public GameResultRepository(Orchestrate.Net.Orchestrate orchestrate)
        {_Orchestrate = orchestrate;
        }

        public IEnumerable<GameResult> GetGameResults()
        {
            return Enumerable.Empty<GameResult>();
        }

        public IEnumerable<GameResult> GetGameResultsForPlayer(Guid playerId)
        {
            return Enumerable.Empty<GameResult>();
        }

        public IEnumerable<GameResult> GetGameResultsForGameType(string gameType)
        {
            return Enumerable.Empty<GameResult>();
        }

        public GameResult RecordGameResults(GameResult gameResult)
        {
            var result = new GameResult(Guid.NewGuid(), gameResult.GameType, gameResult.Team1, gameResult.Team2);
            return result;
        }

        public GameResult UpdateGameResults(GameResult gameResult)
        {
            return gameResult;
        }
    }
}
