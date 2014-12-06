using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;

namespace GameRoom.WebAPI.Controllers
{
    public class PlayerStatesController : ApiController
    {
        private readonly IGameRoomApplication _GameRoom;

        public PlayerStatesController()
            : this(ResourceLocator.GameRoomApplication)
        {
        }

        public PlayerStatesController(IGameRoomApplication gameRoom)
        {
            _GameRoom = gameRoom;
        }

        // GET: PlayerStates
        public IEnumerable<string> Get()
        {
            return _GameRoom.GetPossiblePlayerStates();
        }
    }
}