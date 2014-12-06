using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GameRoom.GameService;
using GameRoom.GameService.Data;
using GameResult = GameRoom.WebAPI.Models.GameResult;
using TeamResult = GameRoom.WebAPI.Models.TeamResult;

namespace GameRoom.WebAPI.Controllers
{
    public class GameResultsController : ApiController
    {
        private readonly IGameRoomApplication _GameRoom;

        public GameResultsController()
            : this(ResourceLocator.GameRoomApplication)
        {
        }

        public GameResultsController(IGameRoomApplication gameRoom)
        {
            _GameRoom = gameRoom;
        }

        // GET: GameResults
        public IEnumerable<GameResult> Get()
        {
            var gameResults = _GameRoom.GetGameResults().HandleFailure(Request);

            return gameResults.Select(ToWebApiModel);
        }

        // GET: GameResults/5
        public IEnumerable<GameResult> Get(int playerId)
        {
            var gameResult = _GameRoom.GetGameResultsForPlayer(playerId).HandleFailure(Request);
            return gameResult.Select(ToWebApiModel);
        }

        // POST: GameResults
        public GameResult Post(GameResult gameResult)
        {
            var request = ToServiceModel(0, gameResult);
            var result = _GameRoom.RecordGameResults(request).HandleFailure(Request);
            return ToWebApiModel(result);
        }

        // PUT: GameResults/1
        public GameResult Put(int id, GameResult gameResult)
        {
            var request = ToServiceModel(id, gameResult);

            var result = _GameRoom.UpdateGameResults(request).HandleFailure(Request);
            return ToWebApiModel(result);
        }

        private static GameService.Data.Models.GameResult ToServiceModel(int id, GameResult gameResult)
        {
            var team1Result = new GameService.Data.Models.TeamResult(gameResult.Team1.Score, gameResult.Team1.Players);
            var team2Result = new GameService.Data.Models.TeamResult(gameResult.Team2.Score, gameResult.Team2.Players);
            var request = new GameService.Data.Models.GameResult(id, gameResult.GameType, team1Result, team2Result);
            return request;
        }

        private static GameResult ToWebApiModel(GameService.Data.Models.GameResult result)
        {
            return new GameResult
            {
                Id = result.Id,
                GameType = result.GameType,
                Team1 =  new TeamResult{
                    Score = result.Team1.Score,
                    Players = result.Team1.Players
                },
                Team2 = new TeamResult
                {
                    Score = result.Team2.Score,
                    Players = result.Team2.Players
                }
            };
        }
    }
}
