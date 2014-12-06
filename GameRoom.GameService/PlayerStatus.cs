using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameRoom.GameService
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

    public interface IPlayerStatusRepository
    {       
        IEnumerable<PlayerStatus> GetPlayerStatuses();

        PlayerStatus GetPlayerStatusForPlayer(int player);

        IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState playerState);

        PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus);
    }

    public class InMemoryPlayerStatusRepository : IPlayerStatusRepository
    {
        private readonly IList<PlayerStatus> _PlayerStatuses;

        public InMemoryPlayerStatusRepository()
        {
            _PlayerStatuses = new List<PlayerStatus>();
        }

        public IEnumerable<PlayerStatus> GetPlayerStatuses()
        {
            return _PlayerStatuses
                .GroupBy(status => status.Player)
                .Select(playerStatuses =>
                    playerStatuses
                        .OrderByDescending(status => status.Reported)
                        .FirstOrDefault());
        }

        public PlayerStatus GetPlayerStatusForPlayer(int player)
        {
            return GetPlayerStatuses()
                    .FirstOrDefault(status => status.Player == player);
        }

        public IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState playerState)
        {
            return GetPlayerStatuses()
                .Where(status => status.State == playerState);
        }

        public PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus)
        {
            _PlayerStatuses.Add(playerStatus);
            return playerStatus;
        }
    }

}