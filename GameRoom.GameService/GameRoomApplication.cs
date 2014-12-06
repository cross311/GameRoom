using System;
using System.Collections.Generic;
using System.Linq;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService
{
    public class GameRoomApplication : IGameRoomApplication
    {
        private readonly GameServiceDataRepository _GameServiceData;

        public GameRoomApplication(Data.GameServiceDataRepository gameServiceData)
        {
            if(ReferenceEquals(gameServiceData, null)) throw new ArgumentNullException("gameServiceData");

            _GameServiceData = gameServiceData;
        }

        public IGameRoomResponse<IEnumerable<GameResult>> GetGameResults()
        {
            var gameResults = _GameServiceData.GameResultRepository.GetGameResults();
            return gameResults.Success();
        }

        public IGameRoomResponse<IEnumerable<GameResult>> GetGameResultsForPlayer(int playerId)
        {
            return _GameServiceData.GameResultRepository.GetGameResultsForPlayer(playerId).Success();
        }

        public IGameRoomResponse<GameResult> RecordGameResults(GameResult gameResult)
        {
            return _GameServiceData.GameResultRepository.RecordGameResults(gameResult).Success();
        }

        public IGameRoomResponse<GameResult> UpdateGameResults(GameResult gameResult)
        {
            return _GameServiceData.GameResultRepository.UpdateGameResults(gameResult).Success();
        }

        public IGameRoomResponse<IEnumerable<GameType>> GetGameTypes()
        {
            return _GameServiceData.GameTypeRepository.GetGameTypes().Success();
        }

        public IGameRoomResponse<IEnumerable<Player>> GetPlayers()
        {
            return _GameServiceData.PlayerRepository.GetPlayers().Success();
        }

        public IGameRoomResponse<Player> GetPlayerForAccessToken(AccessToken accessToken)
        {
            return _GameServiceData.PlayerRepository.GetPlayerForAccessToken(accessToken).Success();
        }

        public IGameRoomResponse<Player> RegisterPlayer(Player player)
        {
            return _GameServiceData.PlayerRepository.RegisterPlayer(player).Success();
        }

        public IGameRoomResponse<IEnumerable<string>> GetPossiblePlayerStates()
        {
            return _GameServiceData.PlayerStateRepository.GetPossiblePlayerStates().Select(state => state.ToString()).Success();
        }

        public IGameRoomResponse<IEnumerable<PlayerStatus>> GetPlayerStatuses()
        {
            return _GameServiceData.PlayerStatusRepository.GetPlayerStatuses().Success();
        }

        public IGameRoomResponse<PlayerStatus> GetPlayerStatusForPlayer(int id)
        {
            return _GameServiceData.PlayerStatusRepository.GetPlayerStatusForPlayer(id).Success();
        }

        public IGameRoomResponse<IEnumerable<PlayerStatus>> GetPlayerStatusesInState(PlayerState state)
        {
            return _GameServiceData.PlayerStatusRepository.GetPlayerStatusesInState(state).Success();
        }

        public IGameRoomResponse<PlayerStatus> UpdatePlayerStatus(PlayerStatus playerStatus)
        {
            return _GameServiceData.PlayerStatusRepository.UpdatePlayerStatus(playerStatus).Success();
        }
    }
}