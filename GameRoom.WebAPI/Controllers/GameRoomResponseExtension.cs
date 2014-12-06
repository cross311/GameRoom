using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;

namespace GameRoom.WebAPI.Controllers
{
    internal static class GameRoomResponseExtension
    {
        public static T HandleFailure<T>(this IGameRoomResponse<T> response, HttpRequestMessage request)
        {
            if(ReferenceEquals(response, null) || ReferenceEquals(request, null))
                throw new HttpResponseException(HttpStatusCode.InternalServerError);

            if(response.ExecutedSuccessfully)
                return response.SuccessfulResponse;

            var failReason = response.FailureReason;
            switch (failReason.ExecutionFailureType)
            {
                case ExecutionFailureTypeEnum.NotFound:
                    throw new HttpResponseException(
                        request.CreateErrorResponse(HttpStatusCode.NotFound, failReason.ExecutionFailureMessage));
                default:
                    throw new HttpResponseException(
                        request.CreateErrorResponse(HttpStatusCode.InternalServerError, failReason.ExecutionFailureMessage));

            }
        }
    }
}