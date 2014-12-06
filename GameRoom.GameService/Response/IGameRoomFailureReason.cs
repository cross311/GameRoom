namespace GameRoom.GameService
{
    public interface IGameRoomFailureReason
    {
        ExecutionFailureTypeEnum ExecutionFailureType { get; }

        string ExecutionFailureMessage { get; }
        
    }
}