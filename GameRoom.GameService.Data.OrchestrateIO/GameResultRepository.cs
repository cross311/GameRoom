using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoom.GameService.Data.Models;
using Orchestrate.Net;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class GameResultRepository : IGameResultRepository
    {
        private const string _GameResultCollectionName = "game_result";
        private readonly int _ReturnLimit;
        private readonly Orchestrate.Net.Orchestrate _Orchestrate;
        private readonly IOrchestrateResultToModelMapper<GameResult> _ModelFactory;

        public GameResultRepository(Orchestrate.Net.Orchestrate orchestrate, IOrchestrateResultToModelMapper<GameResult> modelFactory, int returnLimit)
        {
            if (ReferenceEquals(orchestrate, null)) throw new ArgumentNullException("orchestrate");
            if (ReferenceEquals(modelFactory, null)) throw new ArgumentNullException("modelFactory");
            if (returnLimit > 100 || returnLimit < 1) throw new ArgumentOutOfRangeException("returnLimit", "return limit must be between 1 and 100");

            _Orchestrate = orchestrate;
            _ReturnLimit = returnLimit;
            _ModelFactory = modelFactory;
        }

        public IEnumerable<GameResult> GetGameResults()
        {
            var results = _Orchestrate.List(_GameResultCollectionName, _ReturnLimit, null, null);

            var games = results.Results.Select(BuildGameResult);

            return games;
        }

        public IEnumerable<GameResult> GetGameResultsForPlayer(Guid playerId)
        {
            return Enumerable.Empty<GameResult>();
        }

        public IEnumerable<GameResult> GetGameResultsForGameType(string gameType)
        {
            return Enumerable.Empty<GameResult>();
        }

        public GameResult RecordGameResults(GameResult gameResult)
        {
            var newGameResultId = Guid.NewGuid();
            var newGameResult = new GameResult(newGameResultId, gameResult.GameType, gameResult.Team1, gameResult.Team2);

            var result = _Orchestrate.Put(_GameResultCollectionName, newGameResultId.ToString(), newGameResult);

            return newGameResult;
        }

        public GameResult UpdateGameResults(GameResult gameResult)
        {
            var key = gameResult.Id.ToString();
            var result = _Orchestrate.Put(_GameResultCollectionName, key, gameResult);

            return gameResult;
        }


        private GameResult BuildGameResult(Result result)
        {
            var gameResult = _ModelFactory.Build<JsonGameResult>(result);

            return gameResult;
        }

        private class JsonGameResult : IJsonModel<GameResult>
        {
            public string Id { get; set; }
            public string GameType { get; set; }
            public JsonTeamResult Team1 { get; set; }
            public JsonTeamResult Team2 { get; set; }

            public GameResult ToModel()
            {
                Guid id;
                var idIsGuild = Guid.TryParse(Id, out id);
                if(!idIsGuild) throw new NotSupportedException("JsonGameResult id must be a parsable guid.");

                var team1 = new TeamResult(Team1.Score, Team1.Players);
                var team2 = new TeamResult(Team2.Score, Team2.Players);
                var gameResult = new GameResult(id, GameType, team1, team2);

                return gameResult;
            }
        }

        private class JsonTeamResult
        {
            public int Score { get; set; }
            public IList<Guid> Players { get; set; }
        }
    }
}
