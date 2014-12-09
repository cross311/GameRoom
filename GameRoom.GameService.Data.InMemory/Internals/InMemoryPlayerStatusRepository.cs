using System;
using System.Collections.Generic;
using System.Linq;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.InMemory
{
    internal class InMemoryPlayerStatusRepository : IPlayerStatusRepository
    {
        private readonly IList<PlayerStatus> _PlayerStatuses;

        public InMemoryPlayerStatusRepository()
        {
            _PlayerStatuses = new List<PlayerStatus>();
        }

        public IEnumerable<PlayerStatus> GetPlayerStatuses()
        {
            return _PlayerStatuses
                .GroupBy(status => status.PlayerId)
                .Select(playerStatuses =>
                    playerStatuses
                        .OrderByDescending(status => status.Reported)
                        .FirstOrDefault());
        }

        public PlayerStatus GetPlayerStatusForPlayer(Guid playerId)
        {
            return GetPlayerStatuses()
                .FirstOrDefault(status => status.PlayerId == playerId);
        }

        public IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState playerState)
        {
            return GetPlayerStatuses()
                .Where(status => status.State == playerState);
        }

        public PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus)
        {
            _PlayerStatuses.Add(playerStatus);
            return playerStatus;
        }
    }
}