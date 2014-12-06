using System.Collections.Generic;

namespace GameRoom.GameService.Data
{
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