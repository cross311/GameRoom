using System;

namespace GameRoom.GameService
{
    internal class GameRoomSuccessfulResponse<T> : IGameRoomResponse<T>
    {
        private readonly T _Response;

        public GameRoomSuccessfulResponse(T response)
        {
            _Response = response;
        }
        
        public bool ExecutedSuccessfully
        {
            get { return true; }
        }

        public T SuccessfulResponse
        {
            get { return _Response; }
        }

        public IGameRoomFailureReason FailureReason
        {
            get { return GameRoomFailureReason.NoneFailureReason; }
        }
    }
}