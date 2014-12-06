using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace GameRoom.GameService
{
    public enum PlayerState
    {
        NotAvailable,
        Available,
        Playing
    }

    public interface IPlayerStateRepository
    {
        IEnumerable<PlayerState> GetPossiblePlayerStates();
    }

    public class InMemoryPlayerStateRepository : IPlayerStateRepository
    {
        private readonly PlayerState[] _PlayerStates;

        public InMemoryPlayerStateRepository()
        {
            _PlayerStates = new[]
            {
                PlayerState.NotAvailable,
                PlayerState.Available,
                PlayerState.Playing
            };
        }

        public IEnumerable<PlayerState> GetPossiblePlayerStates()
        {
            return _PlayerStates;
        }
    }

}