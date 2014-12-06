using System.Collections.Generic;
using System.Linq;

namespace GameRoom.GameService.Data
{
    public class InMemoryPlayerStatusRepository : IPlayerStatusRepository
    {
        private readonly IList<PlayerStatus> _PlayerStatuses;

        public InMemoryPlayerStatusRepository()
        {
            _PlayerStatuses = new List<PlayerStatus>();
        }

        public IEnumerable<PlayerStatus> GetPlayerStatuses()
        {
            return _PlayerStatuses
                .GroupBy(status => status.Player)
                .Select(playerStatuses =>
                    playerStatuses
                        .OrderByDescending(status => status.Reported)
                        .FirstOrDefault());
        }

        public PlayerStatus GetPlayerStatusForPlayer(int player)
        {
            return GetPlayerStatuses()
                .FirstOrDefault(status => status.Player == player);
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