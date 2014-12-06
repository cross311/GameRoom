namespace GameRoom.GameService
{
    internal static class GameRoomResponseExtension
    {
        public static IGameRoomResponse<T> Success<T>(this T response)
        {
            var successResponse = new GameRoomSuccessfulResponse<T>(response);
            return successResponse;
        }

        public static IGameRoomResponse<T> WithFailureMessage<T>(
            this ExecutionFailureTypeEnum failureType,
            string failureMessage, params string[] args)
        {
            if (!ReferenceEquals(args, null))
                failureMessage = string.Format(failureMessage, args);

            var gameRoomFailureReason = new GameRoomFailureReason(failureType, failureMessage);
            var failureResponse = new GameRoomFailureResponse<T>(gameRoomFailureReason);
            return failureResponse;
        }
    }
}