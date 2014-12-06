namespace GameRoom.GameService
{
    internal class GameRoomFailureResponse<T> : IGameRoomResponse<T>
    {
        private readonly IGameRoomFailureReason _FailureReason;

        public GameRoomFailureResponse(IGameRoomFailureReason failureReason)
        {
            _FailureReason = failureReason;
        }

        public bool ExecutedSuccessfully
        {
            get { return false; }
        }

        public T SuccessfulResponse
        {
            get { return default(T); }
        }

        public IGameRoomFailureReason FailureReason
        {
            get { return _FailureReason; }
        }
    }
}