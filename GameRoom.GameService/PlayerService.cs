using System;
using System.Collections.Generic;
using System.Linq;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;
using GameRoom.GameService.Response;

namespace GameRoom.GameService
{
    internal class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _PlayerRepository;
        private readonly IPlayerStateRepository _PlayerStateRepository;

        public PlayerService(
            IPlayerRepository playerRepository,
            IPlayerStateRepository playerStateRepository)
        {
            if (ReferenceEquals(playerRepository, null)) throw new ArgumentNullException("playerRepository");
            if (ReferenceEquals(playerStateRepository, null)) throw new ArgumentNullException("playerStateRepository");

            _PlayerRepository = playerRepository;
            _PlayerStateRepository = playerStateRepository;
        }

        public IGameRoomResponse<IEnumerable<string>> AvailableStates()
        {
            return _PlayerStateRepository.GetPossiblePlayerStates().Select(state => state.ToString()).Success();
        }

        public IGameRoomResponse<IEnumerable<Player>> All()
        {
            return _PlayerRepository.GetPlayers().Success();
        }

        public IGameRoomResponse<Player> ForAccessToken(AccessToken accessToken)
        {
            return _PlayerRepository.GetPlayerForAccessToken(accessToken).Success();
        }

        public IGameRoomResponse<Player> Register(Player player)
        {
            return _PlayerRepository.RegisterPlayer(player).Success();
        }
    }
}