using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class PlayerRepository : IPlayerRepository
    {
        private Orchestrate.Net.Orchestrate _Orchestrate;

        public PlayerRepository(Orchestrate.Net.Orchestrate orchestrate)
        {
            _Orchestrate = orchestrate;
        }

        public Models.Player RegisterPlayer(Models.Player player)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Player> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public Models.Player GetPlayerForAccessToken(Models.AccessToken accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
