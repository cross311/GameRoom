using System.Collections.Generic;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService
{
    public interface IPlayerService
    {
        IGameRoomResponse<IEnumerable<string>> AvailableStates();

        IGameRoomResponse<IEnumerable<Player>> All();

        IGameRoomResponse<Player> ForAccessToken(AccessToken accessToken);

        IGameRoomResponse<Player> Register(Player player);
    }
}