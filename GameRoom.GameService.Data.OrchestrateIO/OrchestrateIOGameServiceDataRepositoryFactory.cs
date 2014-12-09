using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRoom.GameService.Data.OrchestrateIO
{
    public class OrchestrateIOGameServiceDataRepositoryFactory : IGameServiceDataRepositoryFactory
    {
        private readonly string _ApiKey;
        private readonly IPlayerStateRepository _PlayerStateRepository;
        private readonly IGameTypeRepository _GameTypeRepository;

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
        }

        public GameServiceDataRepository Build()
        {
            var orchestrate = new Orchestrate.Net.Orchestrate(_ApiKey);

            var repository = new GameServiceDataRepository(
                   new PlayerRepository(orchestrate),
                   new GameResultRepository(orchestrate),
                   new PlayerStatusRepository(orchestrate),
                   _GameTypeRepository,
                   _PlayerStateRepository);

            return repository;
        }
    }
}
