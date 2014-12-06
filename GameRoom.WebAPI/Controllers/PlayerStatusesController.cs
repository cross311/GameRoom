using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;
using PlayerStatus = GameRoom.WebAPI.Models.PlayerStatus;

namespace GameRoom.WebAPI.Controllers
{
    public class PlayerStatusesController : ApiController
    {
        private readonly IPlayerStatusRepository _PlayerStatusRepository;

        public PlayerStatusesController()
            : this(ResourceLocator.PlayerStatusRepository)
        {
        }

        public PlayerStatusesController(IPlayerStatusRepository playerStatusRepository)
        {
            _PlayerStatusRepository = playerStatusRepository;
        }

        // GET: PlayerStatuses
        public IEnumerable<PlayerStatus> Get()
        {
            return _PlayerStatusRepository.GetPlayerStatuses().Select(ToWebApiModel);
        }

        // GET: PlayerStatuses/5
        public PlayerStatus Get(int id)
        {
            var result = _PlayerStatusRepository.GetPlayerStatusForPlayer(id);
            return ToWebApiModel(result);
        }

        // GET: PlayerStatuses?state=availble
        public IEnumerable<PlayerStatus> Get(PlayerState state)
        {
            return _PlayerStatusRepository.GetPlayerStatusesInState(state).Select(ToWebApiModel);
        }

        // POST: PlayerStatuses
        public PlayerStatus Post(PlayerStatus playerStatus)
        {
            var request = ToServiceModel(playerStatus);
            var result = _PlayerStatusRepository.UpdatePlayerStatus(request);
            return ToWebApiModel(result);
        }

        private static GameService.Data.PlayerStatus ToServiceModel(PlayerStatus playerStatus)
        {
            PlayerState state;
            if(!Enum.TryParse(playerStatus.State, true, out state))
                state = PlayerState.NotAvailable;

            var request = new GameService.Data.PlayerStatus(playerStatus.Player, state, playerStatus.Message, playerStatus.Reported ?? DateTime.UtcNow);
            return request;
        }

        private static PlayerStatus ToWebApiModel(GameService.Data.PlayerStatus result)
        {
            return new PlayerStatus
            {
                Player =  result.Player,
                State = result.State.ToString(),
                Message =  result.Message,
                Reported = result.Reported
            };
        }
    }
}
