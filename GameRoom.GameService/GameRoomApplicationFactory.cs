using System;
using GameRoom.GameService.Data;

namespace GameRoom.GameService
{
    public class GameRoomApplicationFactory
    {
        private readonly GameServiceDataRepository _GameServiceData;

        public GameRoomApplicationFactory(GameServiceDataRepository gameServiceData)
        {
            if (ReferenceEquals(gameServiceData, null)) throw new ArgumentNullException("gameServiceData");
            _GameServiceData = gameServiceData;
        }

        public IGameRoomApplication Build()
        {
            var gameResultService = new GameResultService(_GameServiceData.GameTypeRepository, _GameServiceData.GameResultRepository);
            var playerService = new PlayerService(_GameServiceData.PlayerRepository, _GameServiceData.PlayerStateRepository);
            var playerStatusService = new PlayerStatusService(_GameServiceData.PlayerStatusRepository);

            var application = new GameRoomApplication(
                gameResultService,
                playerService,
                playerStatusService);

            return application;
        }
    }
}