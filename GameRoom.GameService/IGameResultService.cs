using System.Collections.Generic;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService
{
    public interface IGameResultService
    {
        IGameRoomResponse<IEnumerable<GameType>> AvailableGameTypes();

        IGameRoomResponse<IEnumerable<GameResult>> All();

        IGameRoomResponse<IEnumerable<GameResult>> AllForPlayer(int playerId);

        IGameRoomResponse<GameResult> Record(GameResult gameResult);

        IGameRoomResponse<GameResult> Update(GameResult gameResult);
    }
}