using System.Collections.Generic;
using System.Linq;

namespace GameRoom.GameService.Data
{
    public class InMemoryPlayerRegistration : IPlayerRegistration
    {
        private readonly IList<Player> _Players;

        public InMemoryPlayerRegistration()
        {
            _Players = new List<Player>();
        }

        public Player RegisterPlayer(PlayerRegistration playerRegistration)
        {
            var newPlayer = new Player(_Players.Count + 1, playerRegistration.Name, playerRegistration.Email);

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