﻿using System;
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
        private readonly IGameResultService _GameResultService;

        public GameResultsController(IGameRoomApplication gameRoom)
        {
            _GameResultService = gameRoom.GameResult;
        }

        // GET: GameResults
        public IEnumerable<GameResult> Get()
        {
            var gameResults = _GameResultService.All().HandleFailure(Request);

            return gameResults.Select(ToWebApiModel);
        }

        // GET: GameResults/5
        public IEnumerable<GameResult> Get(Guid playerId)
        {
            var gameResult = _GameResultService.AllForPlayer(playerId).HandleFailure(Request);
            return gameResult.Select(ToWebApiModel);
        }

        // POST: GameResults
        public GameResult Post(GameResult gameResult)
        {
            var request = ToServiceModel(Guid.Empty, gameResult);
            var result = _GameResultService.Record(request).HandleFailure(Request);
            return ToWebApiModel(result);
        }

        // PUT: GameResults/1234-...
        public GameResult Put(Guid id, GameResult gameResult)
        {
            var request = ToServiceModel(id, gameResult);

            var result = _GameResultService.Update(request).HandleFailure(Request);
            return ToWebApiModel(result);
        }

        private static GameService.Data.Models.GameResult ToServiceModel(Guid id, GameResult gameResult)
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
