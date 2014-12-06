using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService
{
    public interface IGameRoomApplication
    {
        IGameRoomResponse<IEnumerable<GameResult>> GetGameResults();

        IGameRoomResponse<IEnumerable<GameResult>> GetGameResultsForPlayer(int playerId);

        IGameRoomResponse<GameResult> RecordGameResults(GameResult gameResult);

        IGameRoomResponse<GameResult> UpdateGameResults(GameResult gameResult);

        IGameRoomResponse<IEnumerable<GameType>> GetGameTypes();

        IGameRoomResponse<IEnumerable<Player>> GetPlayers();

        IGameRoomResponse<Player> GetPlayerForAccessToken(AccessToken accessToken);

        IGameRoomResponse<Player> RegisterPlayer(Player player);

        IGameRoomResponse<IEnumerable<string>> GetPossiblePlayerStates();

        IGameRoomResponse<IEnumerable<PlayerStatus>> GetPlayerStatuses();

        IGameRoomResponse<PlayerStatus> GetPlayerStatusForPlayer(int id);

        IGameRoomResponse<IEnumerable<PlayerStatus>> GetPlayerStatusesInState(PlayerState state);

        IGameRoomResponse<PlayerStatus> UpdatePlayerStatus(PlayerStatus playerStatus);
    }
}
