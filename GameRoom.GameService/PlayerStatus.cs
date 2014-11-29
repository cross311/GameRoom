using System.Collections;
using System.Collections.Generic;

namespace GameRoom.GameService
{
    public class PlayerStatus
    {
        private readonly int _Player;
        private readonly PlayerState _State;
        private readonly string _Message;

        public PlayerStatus(int player, PlayerState state, string message)
        {
            _Player = player;
            _State = state;
            _Message = message;
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
    }

    public enum PlayerState
    {
        NotAvailable,
        Available,
        Playing
    }

    public interface IPlayerStatusRepository
    {
        IEnumerable<PlayerStatus> GetPlayerStatuses();

        PlayerStatus GetPlayerStatusForPlayer(int player);

        IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState playerState);

        PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus);
    }
}