using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;
using Player = GameRoom.WebAPI.Models.Player;

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

            return players.Select(ToWebApiModel);
        }

        // GET: Players/5
        public Player Get(int id)
        {
            var accessToken = new AccessToken(id);
            var player = _PlayerRepository.GetPlayerForAccessToken(accessToken);

            return ToWebApiModel(player);
        }

        // POST: Players
        public Player Post(Player player)
        {
            var request = ToServiceModel(player);
            var result = _PlayerRepository.RegisterPlayer(request);

            return ToWebApiModel(result);
        }



        private static GameService.Data.Player ToServiceModel(Player player)
        {
            var request = new GameService.Data.Player(player.Name, player.Email);
            return request;
        }

        private static Player ToWebApiModel(GameService.Data.Player result)
        {
            return new Player
            {
                Id = result.Id,
                Name = result.Name,
                Email = result.Email
            };
        }
    }
}
