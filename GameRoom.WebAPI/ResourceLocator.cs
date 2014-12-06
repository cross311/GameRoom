using GameRoom.GameService;
using GameRoom.GameService.Data;

namespace GameRoom.WebAPI
{
    internal static class ResourceLocator
    {
        public static readonly GameServiceDataRepository GameServiceData = new InMemoryGameServiceDataRepositoryFactory().Build();
    }
}