namespace GameRoom.GameService.Data.Models
{
    public class Player
    {
        private const int _UnsavedPlayerId = 0;
        private readonly int _Id;
        private readonly string _Name;
        private readonly string _Email;

        public Player(string name, string email)
            : this(_UnsavedPlayerId, name, email)
        { }

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

        public bool IsNewPlayer()
        {
            return _Id == _UnsavedPlayerId;
        }
    }
}