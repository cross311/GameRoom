using System;

namespace GameRoom.GameService.Data.Models
{
    public class AccessToken
    {
        private readonly Guid _PlayerId;

        public AccessToken(Guid playerId)
        {
            _PlayerId = playerId;
        }

        public Guid PlayerId
        {
            get { return _PlayerId; }
        }
    }
}