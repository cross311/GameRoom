using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;

namespace GameRoom.WebAPI.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly IPlayerRepository _PlayerRepository;

        public PlayersController()
            : this(ResourceLocator.PlayerRepository)
        {
        }

        public PlayersController(IPlayerRepository playerRepository)
        {
            _PlayerRepository = playerRepository;
        }

        // GET: Players
        public IEnumerable<Player> Get()
        {
            var players = _PlayerRepository.GetPlayers();

            return players;
        }

        // GET: Players/5
        public Player Get(int id)
        {
            var accessToken = new AccessToken(id);
            var player = _PlayerRepository.GetPlayerForAccessToken(accessToken);

            return player;
        }

        // POST: Players
        public Player Post(PlayerRegistration registration)
        {
            var player = _PlayerRepository.RegisterPlayer(registration);

            return player;
        }
    }
}
