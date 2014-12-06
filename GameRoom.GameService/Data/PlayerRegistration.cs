using System.Collections.Generic;
using System.Linq;

namespace GameRoom.GameService.Data
{
    public class PlayerRegistration
    {
        private readonly string _Email;
        private readonly string _Name;

        public PlayerRegistration(string email, string name)
        {
            _Email = email;
            _Name = name;
        }

        public string Email
        {
            get { return _Email; }
        }

        public string Name
        {
            get { return _Name; }
        }
    }

    public class Player
    {
        private readonly int _Id;
        private readonly string _Name;
        private readonly string _Email;

        public Player(int id, string name, string email)
        {
            _Id = id;
            _Name = name;
            _Email = email;
        }

        public int Id
        {
            get { return _Id; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Email
        {
            get { return _Email; }
        }
    }

    public class AccessToken
    {
        private readonly int _PlayerId;

        public AccessToken(int playerId)
        {
            _PlayerId = playerId;
        }

        public int PlayerId
        {
            get { return _PlayerId; }
        }
    }


    public interface IPlayerRegistration
    {
        Player RegisterPlayer(PlayerRegistration playerRegistration);

        IEnumerable<Player> GetPlayers();

        Player GetPlayerForAccessToken(AccessToken accessToken);
    }

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