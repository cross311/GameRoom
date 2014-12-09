using System;

namespace GameRoom.GameService.Data.Models
{
    public class PlayerStatus
    {
        private readonly Guid _PlayerId;
        private readonly PlayerState _State;
        private readonly string _Message;
        private readonly DateTime _Reported;

        public PlayerStatus(Guid playerId, PlayerState state, string message, DateTime reported)
        {
            _PlayerId = playerId;
            _State = state;
            _Message = message;
            _Reported = reported;
        }

        public Guid PlayerId
        {
            get { return _PlayerId; }
        }

        public PlayerState State
        {
            get { return _State; }
        }

        public string Message
        {
            get { return _Message; }
        }

        public DateTime Reported
        {
            get { return _Reported; }
        }
    }
}