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
        private readonly IGameRoomApplication _GameRoom;

        public PlayersController()
            : this(ResourceLocator.GameRoomApplication)
        {
        }

        public PlayersController(IGameRoomApplication gameRoom)
        {
            _GameRoom = gameRoom;
        }

        // GET: Players
        public IEnumerable<Player> Get()
        {
            var players = _GameRoom.GetPlayers().HandleFailure(Request);

            return players.Select(ToWebApiModel);
        }

        // GET: Players/5
        public Player Get(int id)
        {
            var accessToken = new AccessToken(id);
            var player = _GameRoom.GetPlayerForAccessToken(accessToken).HandleFailure(Request);

            return ToWebApiModel(player);
        }

        // POST: Players
        public Player Post(Player player)
        {
            var request = ToServiceModel(player);
            var result = _GameRoom.RegisterPlayer(request).HandleFailure(Request);

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
