namespace GameRoom.GameService.Data.OrchestrateIO
{
    internal interface IJsonModel<out TModel>
    {
        TModel ToModel();
    }
}