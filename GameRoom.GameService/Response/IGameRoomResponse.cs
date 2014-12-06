namespace GameRoom.GameService
{
    public interface IGameRoomResponse< out T>
    {
        bool ExecutedSuccessfully { get; }

        T SuccessfulResponse { get; }

        IGameRoomFailureReason FailureReason { get; }
    }
}