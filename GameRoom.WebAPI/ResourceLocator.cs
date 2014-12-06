using GameRoom.GameService;
using GameRoom.GameService.Data;

namespace GameRoom.WebAPI
{
    internal static class ResourceLocator
    {
        private static readonly IDataRepositoryFactory _DataRepositoryFactory = new InMemoryDataRepositoryFactory();
        public readonly static IPlayerRepository PlayerRepository = _DataRepositoryFactory.BuildPlayerRepository();
        public readonly static IGameResultRepository GameResultRepository = _DataRepositoryFactory.BuildGameResultRepository();
        public readonly static IGameTypeRepository GameTypeRepository = _DataRepositoryFactory.BuildGameTypeRepository();
        public readonly static IPlayerStatusRepository PlayerStatusRepository = _DataRepositoryFactory.BuildPlayerStatusRepository();
        public readonly static IPlayerStateRepository PlayerStateRepository = new InMemoryPlayerStateRepository();
    }
}