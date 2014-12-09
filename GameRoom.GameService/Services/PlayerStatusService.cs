using System;
using System.Collections.Generic;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService.Services
{
    internal class PlayerStatusService : IPlayerStatusService
    {
        private readonly IPlayerStatusRepository _PlayerStatusRepository;

        public PlayerStatusService(IPlayerStatusRepository playerStatusRepository)
        {
            if(ReferenceEquals(playerStatusRepository, null)) throw new ArgumentNullException("playerStatusRepository");

            _PlayerStatusRepository = playerStatusRepository;
        }

        public IGameRoomResponse<IEnumerable<PlayerStatus>> All()
        {
            return _PlayerStatusRepository.GetPlayerStatuses().Success();
        }

        public IGameRoomResponse<PlayerStatus> ForPlayer(Guid playerId)
        {
            return _PlayerStatusRepository.GetPlayerStatusForPlayer(playerId).Success();
        }

        public IGameRoomResponse<IEnumerable<PlayerStatus>> AllInState(PlayerState state)
        {
            return _PlayerStatusRepository.GetPlayerStatusesInState(state).Success();
        }

        public IGameRoomResponse<PlayerStatus> Update(PlayerStatus playerStatus)
        {
            return _PlayerStatusRepository.UpdatePlayerStatus(playerStatus).Success();
        }
    }
}