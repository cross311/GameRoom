using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class PlayerRepository : IPlayerRepository
    {
        private Orchestrate.Net.Orchestrate _Orchestrate;

        public PlayerRepository(Orchestrate.Net.Orchestrate orchestrate)
        {
            _Orchestrate = orchestrate;
        }

        public Player RegisterPlayer(Player player)
        {
            var result = new Player(Guid.NewGuid(), player.Name, player.Email);
            return result;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return Enumerable.Empty<Player>();
        }

        public Player GetPlayerForAccessToken(AccessToken accessToken)
        {
            var result = new Player(accessToken.PlayerId, "Connor Ross", "cross@mdsol.com");
            return result;
        }
    }
}
