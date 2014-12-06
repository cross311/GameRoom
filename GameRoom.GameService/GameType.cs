using System.Collections.Generic;

namespace GameRoom.GameService
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
        public static GameType Pool = new GameType("Pool");
        public static GameType Fifa = new GameType("Fifa");
    }



    public interface IGameTypeRepository
    {
        IList<GameType> GetGameTypes();
    }
}