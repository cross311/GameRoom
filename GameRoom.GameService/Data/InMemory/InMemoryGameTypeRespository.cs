using System.Collections.Generic;

namespace GameRoom.GameService.Data
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