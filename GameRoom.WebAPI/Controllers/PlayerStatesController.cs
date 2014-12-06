using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;

namespace GameRoom.WebAPI.Controllers
{
    public class PlayerStatesController : ApiController
    {
        private readonly IPlayerStateRepository _PlayerStateRepository;

        public PlayerStatesController()
            : this(ResourceLocator.PlayerStateRepository)
        {
        }

        public PlayerStatesController(IPlayerStateRepository playerStateRepository)
        {
            _PlayerStateRepository = playerStateRepository;
        }

        // GET: PlayerStates
        public IEnumerable<string> Get()
        {
            return _PlayerStateRepository.GetPossiblePlayerStates().Select(state => state.ToString());
        }
    }
}