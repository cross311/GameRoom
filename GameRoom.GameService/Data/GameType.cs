using System.Collections.Generic;

namespace GameRoom.GameService.Data
{
    public class GameType
    {
        private readonly string _Name;

        public GameType(string name)
        {
            _Name = name;
        }

        public string Name
        {
            get { return _Name; }
        }

        public static GameType Foosball = new GameType("Foosball");
        public static GameType Pool =     new GameType("Pool");
        public static GameType Fifa =     new GameType("Fifa");
    }



    public interface IGameTypeRepository
    {
        IEnumerable<GameType> GetGameTypes();
    }

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