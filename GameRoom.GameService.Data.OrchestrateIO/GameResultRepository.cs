using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class GameResultRepository : IGameResultRepository
    {
        private Orchestrate.Net.Orchestrate _Orchestrate;

        public GameResultRepository(Orchestrate.Net.Orchestrate orchestrate)
        {_Orchestrate = orchestrate;
        }

        public IEnumerable<Models.GameResult> GetGameResults()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.GameResult> GetGameResultsForPlayer(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.GameResult> GetGameResultsForGameType(string gameType)
        {
            throw new NotImplementedException();
        }

        public Models.GameResult RecordGameResults(Models.GameResult gameResult)
        {
            throw new NotImplementedException();
        }

        public Models.GameResult UpdateGameResults(Models.GameResult gameResult)
        {
            throw new NotImplementedException();
        }
    }
}
