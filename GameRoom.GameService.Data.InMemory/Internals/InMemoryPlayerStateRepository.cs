using System.Collections.Generic;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.InMemory
{
    internal class InMemoryPlayerStateRepository : IPlayerStateRepository
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