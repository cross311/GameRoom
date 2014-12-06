using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;

namespace GameRoom.WebAPI.Controllers
{
    public class PlayerStatesController : ApiController
    {
        private readonly IPlayerService _PlayerService;

        public PlayerStatesController(IGameRoomApplication gameRoom)
        {
            _PlayerService = gameRoom.Player;
        }

        // GET: PlayerStates
        public IEnumerable<string> Get()
        {
            return _PlayerService.AvailableStates().HandleFailure(Request);
        }
    }
}