namespace GameRoom.GameService.Data.InMemory
{
    public class InMemoryGameServiceDataRepositoryFactory : IGameServiceDataRepositoryFactory
    {
        public GameServiceDataRepository Build()
        {
            var repository = new GameServiceDataRepository(
                new InMemoryPlayerRepository(),
                new InMemoryGameResultRepository(),
                new InMemoryPlayerStatusRepository(),
                new InMemoryGameTypeRespository(),
                new InMemoryPlayerStateRepository());

            return repository;
        }
    }
}