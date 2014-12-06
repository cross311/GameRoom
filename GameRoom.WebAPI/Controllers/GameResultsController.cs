﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameRoom.GameService;
using GameResult = GameRoom.WebAPI.Models.GameResult;
using TeamResult = GameRoom.WebAPI.Models.TeamResult;

namespace GameRoom.WebAPI.Controllers
{
    public class GameResultsController : ApiController
    {
        private readonly IGameResultRepository _GameResultRepository;
        private static readonly InMemoryGameResultRepository _inMemoryGameResultRepository = new InMemoryGameResultRepository();

        public GameResultsController()
            : this(_inMemoryGameResultRepository)
        {
        }

        public GameResultsController(IGameResultRepository gameResultRepository)
        {
            _GameResultRepository = gameResultRepository;
        }

        // GET: GameResults
        public IEnumerable<GameResult> Get()
        {
            var gameResults = _GameResultRepository.GetGameResults();

            return gameResults.Select(ToWebApiModel);
        }

        // GET: GameResults/5
        public IEnumerable<GameResult> Get(int playerId)
        {
            var gameResult = _GameResultRepository.GetGameResultsForPlayer(playerId);
            return gameResult.Select(ToWebApiModel);
        }

        // POST: GameResults
        public GameResult Post(GameResult gameResult)
        {
            var request = ToServiceModel(0, gameResult);
            var result = _GameResultRepository.RecordGameResults(request);
            return ToWebApiModel(result);
        }

        // PUT: GameResults/1
        public GameResult Put(int id, GameResult gameResult)
        {
            var request = ToServiceModel(id, gameResult);

            var result = _GameResultRepository.UpdateGameResults(request);
            return ToWebApiModel(result);
        }

        private static GameService.GameResult ToServiceModel(int id, GameResult gameResult)
        {
            var team1Result = new GameService.TeamResult(gameResult.Team1.Score, gameResult.Team1.Players);
            var team2Result = new GameService.TeamResult(gameResult.Team2.Score, gameResult.Team2.Players);
            var request = new GameService.GameResult(id, gameResult.GameType, team1Result, team2Result);
            return request;
        }

        private static GameResult ToWebApiModel(GameService.GameResult result)
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
