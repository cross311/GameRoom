namespace GameRoom.GameService.Response
{
    public interface IGameRoomResponse< out T>
    {
        bool ExecutedSuccessfully { get; }

        T SuccessfulResponse { get; }

        IGameRoomFailureReason FailureReason { get; }
    }
}