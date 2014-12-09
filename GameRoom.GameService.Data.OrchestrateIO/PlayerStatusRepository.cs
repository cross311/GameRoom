using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    class PlayerStatusRepository : IPlayerStatusRepository
    {
        private const string _PlayerStatusCollectionName = "player_status";
        private readonly int _ReturnLimit;
        private readonly Orchestrate.Net.Orchestrate _Orchestrate;
        private readonly IOrchestrateResultToModelMapper<PlayerStatus> _ModelFactory;

        public PlayerStatusRepository(Orchestrate.Net.Orchestrate orchestrate, IOrchestrateResultToModelMapper<PlayerStatus> modelFactory, int returnLimit)
        {
            if (ReferenceEquals(orchestrate, null)) throw new ArgumentNullException("orchestrate");
            if (ReferenceEquals(modelFactory, null)) throw new ArgumentNullException("modelFactory");
            if(returnLimit > 100 || returnLimit < 1) throw new ArgumentOutOfRangeException("returnLimit", "return limit must be between 1 and 100");

            _Orchestrate = orchestrate;
            _ModelFactory = modelFactory;
            _ReturnLimit = returnLimit;
        }

        public IEnumerable<PlayerStatus> GetPlayerStatuses()
        {
            var results = _Orchestrate.List(_PlayerStatusCollectionName, _ReturnLimit, null, null);

            var statuses = results.Results.Select(BuildPlayerStatus)
                .GroupBy(status => status.PlayerId)
                .Select(playerStatuses =>
                    playerStatuses
                        .OrderByDescending(status => status.Reported)
                        .FirstOrDefault());

            return statuses;
        }

        private PlayerStatus BuildPlayerStatus(Orchestrate.Net.Result result)
        {
            return _ModelFactory.Build<JsonPlayerStatus>(result);
        }

        public PlayerStatus GetPlayerStatusForPlayer(Guid playerId)
        {
            return new PlayerStatus(playerId, PlayerState.NotAvailable, string.Empty, DateTime.UtcNow);
        }

        public IEnumerable<PlayerStatus> GetPlayerStatusesInState(PlayerState playerState)
        {
            return Enumerable.Empty<PlayerStatus>();
        }

        public PlayerStatus UpdatePlayerStatus(PlayerStatus playerStatus)
        {
            var key = Guid.NewGuid();

            _Orchestrate.Put(_PlayerStatusCollectionName, key.ToString(), playerStatus);
            return playerStatus;
        }

        class JsonPlayerStatus : IJsonModel<PlayerStatus>
        {
            public string PlayerId { get; set; }
            public PlayerState State { get; set; }
            public string Message { get; set; }
            public DateTime Reported { get; set; }

            public PlayerStatus ToModel()
            {
                Guid playerid;
                var idIsGuild = Guid.TryParse(PlayerId, out playerid);
                if(!idIsGuild) throw new NotSupportedException("JsonPlayerStatus id must be a parsable guid.");


                var status = new PlayerStatus(playerid, State, Message, Reported);
                return status;
            }
        }
    }
}
