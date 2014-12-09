using System;
using System.Collections.Generic;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data
{
    public interface IPlayerStatusRepository
    {       
        IEnumerable<PlayerStatus> GetPlayerStatuses();

        PlayerStatus GetPlayerStatusForPlayer(Guid playerId);

        IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState playerState);

        PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus);
    }
}