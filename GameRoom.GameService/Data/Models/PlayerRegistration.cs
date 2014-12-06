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
}