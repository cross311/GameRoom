using System.Collections.Generic;
using System.Linq;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.InMemory
{
    internal class InMemoryPlayerRepository : IPlayerRepository
    {
        private readonly IList<Player> _Players;

        public InMemoryPlayerRepository()
        {
            _Players = new List<Player>();
        }

        public Player RegisterPlayer(Player player)
        {
            var newPlayer = new Player(_Players.Count + 1, player.Name, player.Email);

            _Players.Add(newPlayer);

            return newPlayer;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _Players;
        }

        public Player GetPlayerForAccessToken(AccessToken accessToken)
        {
            var player = _Players.SingleOrDefault(p => p.Id == accessToken.PlayerId);
            return player;
        }
    }
}