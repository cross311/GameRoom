using System;

namespace GameRoom.GameService.Data.Models
{
    public class Player
    {
        private readonly Guid _Id;
        private readonly string _Name;
        private readonly string _Email;

        public Player(string name, string email)
            : this(Guid.Empty, name, email)
        { }

        public Player(Guid id, string name, string email)
        {
            _Id = id;
            _Name = name;
            _Email = email;
        }

        public Guid Id
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

        public bool IsNewPlayer()
        {
            return _Id == Guid.Empty;
        }
    }
}