namespace GameRoom.GameService.Data
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