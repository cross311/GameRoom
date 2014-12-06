using System.Collections.Generic;

namespace GameRoom.GameService.Data
{
    public interface IPlayerStatusRepository
    {       
        IEnumerable<PlayerStatus> GetPlayerStatuses();

        PlayerStatus GetPlayerStatusForPlayer(int player);

        IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState playerState);

        PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus);
    }
}