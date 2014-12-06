using System;

namespace GameRoom.GameService.Data.Models
{
    public class PlayerStatus
    {
        private readonly int _Player;
        private readonly PlayerState _State;
        private readonly string _Message;
        private readonly DateTime _Reported;

        public PlayerStatus(int player, PlayerState state, string message, DateTime reported)
        {
            _Player = player;
            _State = state;
            _Message = message;
            _Reported = reported;
        }

        public int Player
        {
            get { return _Player; }
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