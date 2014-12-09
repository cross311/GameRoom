using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class PlayerStatusRepository : IPlayerStatusRepository
    {
        private Orchestrate.Net.Orchestrate _Orchestrate;

        public PlayerStatusRepository(Orchestrate.Net.Orchestrate orchestrate)
        {
            _Orchestrate = orchestrate;
        }

        public IEnumerable<Models.PlayerStatus> GetPlayerStatuses()
        {
            throw new NotImplementedException();
        }

        public Models.PlayerStatus GetPlayerStatusForPlayer(Guid playerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.PlayerStatus> GetPlayerStatusesInState(Models.PlayerState playerState)
        {
            throw new NotImplementedException();
        }

        public Models.PlayerStatus UpdatePlayerStatus(Models.PlayerStatus playerStatus)
        {
            throw new NotImplementedException();
        }
    }
}
