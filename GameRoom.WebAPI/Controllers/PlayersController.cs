using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;
using GameRoom.GameService.Data.Models;
using Player = GameRoom.WebAPI.Models.Player;

namespace GameRoom.WebAPI.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly IPlayerService _PlayerService;

        public PlayersController(IGameRoomApplication gameRoom)
        {
            _PlayerService = gameRoom.Player;
        }

        // GET: Players
        public IEnumerable<Player> Get()
        {
            var players = _PlayerService.All().HandleFailure(Request);

            return players.Select(ToWebApiModel);
        }

        // GET: Players/1234-...
        public Player Get(Guid id)
        {
            var accessToken = new AccessToken(id);
            var player = _PlayerService.ForAccessToken(accessToken).HandleFailure(Request);

            return ToWebApiModel(player);
        }

        // POST: Players
        public Player Post(Player player)
        {
            var request = ToServiceModel(player);
            var result = _PlayerService.Register(request).HandleFailure(Request);

            return ToWebApiModel(result);
        }



        private static GameService.Data.Models.Player ToServiceModel(Player player)
        {
            var request = new GameService.Data.Models.Player(player.Name, player.Email);
            return request;
        }

        private static Player ToWebApiModel(GameService.Data.Models.Player result)
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
