namespace GameRoom.GameService.Data
{
    public interface IDataRepositoryFactory
    {
        IPlayerRepository BuildPlayerRepository();

        IGameResultRepository BuildGameResultRepository();

        IPlayerStatusRepository BuildPlayerStatusRepository();

        IGameTypeRepository BuildGameTypeRepository();
    }
}