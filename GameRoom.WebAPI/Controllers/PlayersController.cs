using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;

namespace GameRoom.WebAPI.Controllers
{
    public class PlayersController : ApiController
    {
        private static readonly InMemoryPlayerRegistration _InMemoryPlayerRegistration = new InMemoryPlayerRegistration();
        private readonly IPlayerRegistration _PlayerRegistration;

        public PlayersController()
            : this(_InMemoryPlayerRegistration)
        {
            
        }

        public PlayersController(IPlayerRegistration playerRegistration)
        {
            _PlayerRegistration = playerRegistration;
        }

        // GET: Players
        public IEnumerable<Player> Get()
        {
            var players = _PlayerRegistration.GetPlayers();

            return players;
        }

        // GET: Players/5
        public Player Get(int id)
        {
            var accessToken = new AccessToken(id);
            var player = _PlayerRegistration.GetPlayerForAccessToken(accessToken);

            return player;
        }

        // POST: Players
        public Player Post(PlayerRegistration registration)
        {
            var player = _PlayerRegistration.RegisterPlayer(registration);

            return player;
        }
    }
}
