using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoom.GameService.Data.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Orchestrate.Net;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class PlayerRepository : IPlayerRepository
    {
        private const string _PlayerCollectionName = "player";
        private readonly int _ReturnLimit;
        private readonly Orchestrate.Net.Orchestrate _Orchestrate;
        private readonly IOrchestrateResultToModelMapper<Player> _ModelFactory;

        public PlayerRepository(Orchestrate.Net.Orchestrate orchestrate, IOrchestrateResultToModelMapper<Player> modelFactory, int returnLimit)
        {
            if (ReferenceEquals(orchestrate, null)) throw new ArgumentNullException("orchestrate");
            if (ReferenceEquals(modelFactory, null)) throw new ArgumentNullException("modelFactory");
            if(returnLimit > 100 || returnLimit < 1) throw new ArgumentOutOfRangeException("returnLimit", "return limit must be between 1 and 100");

            _Orchestrate = orchestrate;
            _ModelFactory = modelFactory;
            _ReturnLimit = returnLimit;
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
            var result = _Orchestrate.List(_PlayerCollectionName, _ReturnLimit, null,null);

            var players = result.Results.Select(BuildPlayer);

            return players;
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

        private Player BuildPlayer(Result result)
        {
            var player = _ModelFactory.Build<JsonPlayer>(result);

            return player;
        }

        class JsonPlayer : IJsonModel<Player>
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
