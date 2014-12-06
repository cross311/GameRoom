using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;

namespace GameRoom.WebAPI.Controllers
{
    public class GameTypesController : ApiController
    {
        private readonly IGameTypeRepository _GameTypeRepository;

        public GameTypesController()
            : this(ResourceLocator.GameTypeRepository)
        {
        }

        public GameTypesController(IGameTypeRepository gameTypeRepository)
        {
            _GameTypeRepository = gameTypeRepository;
        }

        public IEnumerable<GameType> Get()
        {
            return _GameTypeRepository.GetGameTypes();
        }
    }
}
