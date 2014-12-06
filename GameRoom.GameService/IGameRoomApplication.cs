using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRoom.GameService.Data;

namespace GameRoom.GameService
{
    public interface IGameRoomApplication
    {
        IEnumerable<GameResult> GetGameResults();

        IEnumerable<GameResult> GetGameResultsForPlayer(int playerId);

        GameResult RecordGameResults(GameResult gameResult);

        GameResult UpdateGameResults(GameResult gameResult);

        IEnumerable<GameType> GetGameTypes();

        IEnumerable<Player> GetPlayers();

        Player GetPlayerForAccessToken(AccessToken accessToken);

        Player RegisterPlayer(Player player);

        IEnumerable<string> GetPossiblePlayerStates();

        IEnumerable<PlayerStatus> GetPlayerStatuses();

        PlayerStatus GetPlayerStatusForPlayer(int id);

        IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState state);

        PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus);
    }

    public class GameRoomApplication : IGameRoomApplication
    {
        private GameServiceDataRepository _GameServiceData;

        public GameRoomApplication(Data.GameServiceDataRepository gameServiceData)
        {
            if(ReferenceEquals(gameServiceData, null)) throw new ArgumentNullException("gameServiceData");

            _GameServiceData = gameServiceData;
        }

        public IEnumerable<GameResult> GetGameResults()
        {
            return _GameServiceData.GameResultRepository.GetGameResults();
        }

        public IEnumerable<GameResult> GetGameResultsForPlayer(int playerId)
        {
            return _GameServiceData.GameResultRepository.GetGameResultsForPlayer(playerId);
        }

        public GameResult RecordGameResults(GameResult gameResult)
        {
            return _GameServiceData.GameResultRepository.RecordGameResults(gameResult);
        }

        public GameResult UpdateGameResults(GameResult gameResult)
        {
            return _GameServiceData.GameResultRepository.UpdateGameResults(gameResult);
        }

        public IEnumerable<GameType> GetGameTypes()
        {
            return _GameServiceData.GameTypeRepository.GetGameTypes();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _GameServiceData.PlayerRepository.GetPlayers();
        }

        public Player GetPlayerForAccessToken(AccessToken accessToken)
        {
            return _GameServiceData.PlayerRepository.GetPlayerForAccessToken(accessToken);
        }

        public Player RegisterPlayer(Player player)
        {
            return _GameServiceData.PlayerRepository.RegisterPlayer(player);
        }

        public IEnumerable<string> GetPossiblePlayerStates()
        {
            return _GameServiceData.PlayerStateRepository.GetPossiblePlayerStates().Select(state => state.ToString());
        }

        public IEnumerable<PlayerStatus> GetPlayerStatuses()
        {
            return _GameServiceData.PlayerStatusRepository.GetPlayerStatuses();
        }

        public PlayerStatus GetPlayerStatusForPlayer(int id)
        {
            return _GameServiceData.PlayerStatusRepository.GetPlayerStatusForPlayer(id);
        }

        public IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState state)
        {
            return _GameServiceData.PlayerStatusRepository.GetPlayerStatusesInState(state);
        }

        public PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus)
        {
            return _GameServiceData.PlayerStatusRepository.UpdatePlayerStatus(playerStatus);
        }
    }
}
