using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRoom.GameService.Data.Models;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    public class OrchestrateIOGameServiceDataRepositoryFactory : IGameServiceDataRepositoryFactory
    {
        private readonly string _ApiKey;
        private readonly IPlayerStateRepository _PlayerStateRepository;
        private readonly IGameTypeRepository _GameTypeRepository;
        private readonly int _ReturnLimit;

        public OrchestrateIOGameServiceDataRepositoryFactory(
            string apiKey,
            IPlayerStateRepository playerStateRepository,
            IGameTypeRepository gameTypeRepository)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException("apiKey");
            if (ReferenceEquals(playerStateRepository, null)) throw new ArgumentNullException("playerStateRepository");
            if (ReferenceEquals(gameTypeRepository, null)) throw new ArgumentNullException("gameTypeRepository");

            _ApiKey = apiKey;
            _PlayerStateRepository = playerStateRepository;
            _GameTypeRepository = gameTypeRepository;
            _ReturnLimit = 100;
        }

        public GameServiceDataRepository Build()
        {
            var orchestrate = new Orchestrate.Net.Orchestrate(_ApiKey);

            var orchestrateResultToModelMapper = new OrchestrateResultToModelMapper<Player>();
            var resultToModelMapper = new OrchestrateResultToModelMapper<GameResult>();
            var repository = new GameServiceDataRepository(
                   new PlayerRepository(orchestrate, orchestrateResultToModelMapper, _ReturnLimit),
                   new GameResultRepository(orchestrate, resultToModelMapper, _ReturnLimit),
                   new PlayerStatusRepository(orchestrate),
                   _GameTypeRepository,
                   _PlayerStateRepository);

            return repository;
        }
    }
}
