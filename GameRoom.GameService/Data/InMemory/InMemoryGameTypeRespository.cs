using System.Collections.Generic;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.InMemory
{
    public class InMemoryGameTypeRespository : IGameTypeRepository
    {
        private readonly GameType[] _GameTypes;

        public InMemoryGameTypeRespository()
        {
            _GameTypes = new []
            {
                new GameType("Foosball"),
                new GameType("Pool"),
                new GameType("Fifa")
            };
        }

        public IEnumerable<GameType> GetGameTypes()
        {
            return _GameTypes;
        }
    }
}