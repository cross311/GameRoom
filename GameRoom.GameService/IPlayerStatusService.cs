using System;
using System.Collections.Generic;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService
{
    public interface IPlayerStatusService
    {
        IGameRoomResponse<IEnumerable<PlayerStatus>> All();

        IGameRoomResponse<PlayerStatus> ForPlayer(Guid playerId);

        IGameRoomResponse<IEnumerable<PlayerStatus>> AllInState(PlayerState state);

        IGameRoomResponse<PlayerStatus> Update(PlayerStatus playerStatus);
        
    }
}