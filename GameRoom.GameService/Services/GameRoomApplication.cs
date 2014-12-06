using System;

namespace GameRoom.GameService.Services
{
    internal class GameRoomApplication : IGameRoomApplication
    {
        private readonly IGameResultService _GameResultService;
        private readonly IPlayerService _PlayerService;
        private readonly IPlayerStatusService _PlayerStatusService;

        public GameRoomApplication(
            IGameResultService gameResultService,
            IPlayerService playerService,
            IPlayerStatusService playerStatusService)
        {
            if (ReferenceEquals(gameResultService, null)) throw new ArgumentNullException("gameResultService");
            if (ReferenceEquals(playerService, null)) throw new ArgumentNullException("playerService");
            if (ReferenceEquals(playerStatusService, null)) throw new ArgumentNullException("playerStatusService");

            _GameResultService = gameResultService;
            _PlayerService = playerService;
            _PlayerStatusService = playerStatusService;
        }

        public IGameResultService GameResult
        {
            get { return _GameResultService; }
        }

        public IPlayerService Player
        {
            get { return _PlayerService; }
        }

        public IPlayerStatusService PlayerStatus
        {
            get { return _PlayerStatusService; }
        }
    }
}