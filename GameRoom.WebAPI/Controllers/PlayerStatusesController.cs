using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;

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
            return _PlayerStatusRepository.GetPlayerStatuses();
        }

        // GET: PlayerStatuses/5
        public PlayerStatus Get(int id)
        {
            return _PlayerStatusRepository.GetPlayerStatusForPlayer(id);
        }

        // GET: PlayerStatuses?state=availble
        public IEnumerable<PlayerStatus> Get(PlayerState state)
        {
            return _PlayerStatusRepository.GetPlayerStatusesInState(state);
        }

        // POST: PlayerStatuses
        public PlayerStatus Post(PlayerStatus playerStatus)
        {
            var result = _PlayerStatusRepository.UpdatePlayerStatus(playerStatus);
            return result;
        }
    }
}
