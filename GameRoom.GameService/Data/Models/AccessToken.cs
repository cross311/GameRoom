namespace GameRoom.GameService.Data.Models
{
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
}