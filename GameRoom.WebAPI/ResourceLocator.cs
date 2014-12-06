using GameRoom.GameService;
using GameRoom.GameService.Data;

namespace GameRoom.WebAPI
{
    internal static class ResourceLocator
    {
        public readonly static IPlayerRepository PlayerRepository = new InMemoryPlayerRepository();
        public readonly static IGameResultRepository GameResultRepository = new InMemoryGameResultRepository();
        public readonly static IGameTypeRepository GameTypeRepository = new InMemoryGameTypeRespository();
        public readonly static IPlayerStatusRepository PlayerStatusRepository = new InMemoryPlayerStatusRepository();
        public readonly static IPlayerStateRepository PlayerStateRepository = new InMemoryPlayerStateRepository();
    }
}