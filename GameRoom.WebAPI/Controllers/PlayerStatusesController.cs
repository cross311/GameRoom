using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;
using PlayerStatus = GameRoom.WebAPI.Models.PlayerStatus;

namespace GameRoom.WebAPI.Controllers
{
    public class PlayerStatusesController : ApiController
    {
        private readonly IGameRoomApplication _GameRoom;

        public PlayerStatusesController()
            : this(ResourceLocator.GameRoomApplication)
        {
        }

        public PlayerStatusesController(IGameRoomApplication gameRoom)
        {
            _GameRoom = gameRoom;
        }

        // GET: PlayerStatuses
        public IEnumerable<PlayerStatus> Get()
        {
            return _GameRoom.GetPlayerStatuses().HandleFailure(Request).Select(ToWebApiModel);
        }

        // GET: PlayerStatuses/5
        public PlayerStatus Get(int id)
        {
            var result = _GameRoom.GetPlayerStatusForPlayer(id).HandleFailure(Request);
            return ToWebApiModel(result);
        }

        // GET: PlayerStatuses?state=availble
        public IEnumerable<PlayerStatus> Get(PlayerState state)
        {
            return _GameRoom.GetPlayerStatusesInState(state).HandleFailure(Request).Select(ToWebApiModel);
        }

        // POST: PlayerStatuses
        public PlayerStatus Post(PlayerStatus playerStatus)
        {
            var request = ToServiceModel(playerStatus);
            var result = _GameRoom.UpdatePlayerStatus(request).HandleFailure(Request);
            return ToWebApiModel(result);
        }

        private static GameService.Data.Models.PlayerStatus ToServiceModel(PlayerStatus playerStatus)
        {
            PlayerState state;
            if(!Enum.TryParse(playerStatus.State, true, out state))
                state = PlayerState.NotAvailable;

            var request = new GameService.Data.Models.PlayerStatus(playerStatus.Player, state, playerStatus.Message, playerStatus.Reported ?? DateTime.UtcNow);
            return request;
        }

        private static PlayerStatus ToWebApiModel(GameService.Data.Models.PlayerStatus result)
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
