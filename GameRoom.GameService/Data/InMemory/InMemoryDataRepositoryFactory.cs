namespace GameRoom.GameService.Data
{
    public class InMemoryDataRepositoryFactory : IDataRepositoryFactory
    {
        public IPlayerRepository BuildPlayerRepository()
        {
            return new InMemoryPlayerRepository();
        }

        public IGameResultRepository BuildGameResultRepository()
        {
            return new InMemoryGameResultRepository();
        }

        public IPlayerStatusRepository BuildPlayerStatusRepository()
        {
            return new InMemoryPlayerStatusRepository();
        }


        public IGameTypeRepository BuildGameTypeRepository()
        {
            return new InMemoryGameTypeRespository();
        }
    }
}