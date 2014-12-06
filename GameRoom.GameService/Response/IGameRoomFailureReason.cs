namespace GameRoom.GameService.Response
{
    public interface IGameRoomFailureReason
    {
        ExecutionFailureTypeEnum ExecutionFailureType { get; }

        string ExecutionFailureMessage { get; }
        
    }
}