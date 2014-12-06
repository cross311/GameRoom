namespace GameRoom.GameService.Response
{
    internal class GameRoomFailureReason : IGameRoomFailureReason
    {
        private readonly ExecutionFailureTypeEnum _ExecutionFailureType;
        private readonly string _ExecutionFailureMessage;

        public GameRoomFailureReason(
            ExecutionFailureTypeEnum executionFailureType,
            string executionFailureMessage)
        {
            _ExecutionFailureType = executionFailureType;
            _ExecutionFailureMessage = executionFailureMessage ?? string.Empty;
        }

        public ExecutionFailureTypeEnum ExecutionFailureType
        {
            get { return _ExecutionFailureType; }
        }

        public string ExecutionFailureMessage
        {
            get { return _ExecutionFailureMessage; }
        }

        public static readonly IGameRoomFailureReason NoneFailureReason = new GameRoomFailureReason(ExecutionFailureTypeEnum.None, string.Empty);
    }
}