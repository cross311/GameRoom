using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class PlayerStatusRepository : IPlayerStatusRepository
    {
        private Orchestrate.Net.Orchestrate _Orchestrate;

        public PlayerStatusRepository(Orchestrate.Net.Orchestrate orchestrate)
        {
            _Orchestrate = orchestrate;
        }

        public IEnumerable<PlayerStatus> GetPlayerStatuses()
        {
            return Enumerable.Empty<PlayerStatus>();
        }

        public PlayerStatus GetPlayerStatusForPlayer(Guid playerId)
        {
            return new PlayerStatus(playerId, PlayerState.NotAvailable, string.Empty, DateTime.UtcNow);
        }

        public IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState playerState)
        {
            return Enumerable.Empty<PlayerStatus>();
        }

        public PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus)
        {
            return playerStatus;
        }
    }
}
