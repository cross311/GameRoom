using GameRoom.GameService;

namespace GameRoom.WebAPI
{
    internal static class ResourceLocator
    {
        public static IPlayerRegistration PlayerRegistration = new InMemoryPlayerRegistration();
        public static IGameResultRepository GameResultRepository = new InMemoryGameResultRepository();
        public static IGameTypeRepository GameTypeRepository = new InMemoryGameTypeRespository();
        //public static IPlayerStatusRepository PlayerStatusRepository = new InMemoryPlayerRegistration();
    }
}