using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoom.GameService.Data.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Orchestrate.Net;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class PlayerRepository : IPlayerRepository
    {
        private const string _PlayerCollectionName = "player";
        private const int _Limit = 100;
        private Orchestrate.Net.Orchestrate _Orchestrate;

        public PlayerRepository(Orchestrate.Net.Orchestrate orchestrate)
        {
            _Orchestrate = orchestrate;
        }

        public Player RegisterPlayer(Player player)
        {
            var newPlayerId = Guid.NewGuid();
            var newPlayer = new Player(newPlayerId, player.Name, player.Email);

            var result = _Orchestrate.Put(_PlayerCollectionName, newPlayerId.ToString(), newPlayer);

            return newPlayer;
        }

        public IEnumerable<Player> GetPlayers()
        {
            var result = _Orchestrate.List(_PlayerCollectionName, _Limit, null,null);

            var players = result.Results.Select(BuildPlayer);

            return players;
        }

        private Player BuildPlayer(Result result)
        {
            if (ReferenceEquals(result, null)) throw new ArgumentNullException("result");
            if (ReferenceEquals(result.Value, null)) throw new NotSupportedException("result.Value must not be null");

            var value = result.Value as JObject;

            if(ReferenceEquals(value, null)) throw new NotSupportedException("result.value must be a JObject");

            var player = value.ToObject<JsonPlayer>();
            return player.ToModel();
        }

        public Player GetPlayerForAccessToken(AccessToken accessToken)
        {
            if (ReferenceEquals(accessToken, null)) throw new ArgumentNullException("accessToken");

            var playerId = accessToken.PlayerId;
            var key = playerId.ToString();
            var result = _Orchestrate.Get(_PlayerCollectionName, key);

            var playerForAccessToken = BuildPlayer(result);
            return playerForAccessToken;
        }

        class JsonPlayer
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public Player ToModel()
            {
                Guid id;
                var idIsGuild = Guid.TryParse(Id, out id);
                if(!idIsGuild) throw new NotSupportedException("jsonPlayer id must be a parsable guid.");

                return new Player(id: id, name: Name, email: Email);
            }
        }
    }
}
